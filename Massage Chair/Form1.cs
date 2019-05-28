using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace Massage_Chair
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Class to keep track of string and color for lines in output window.
        /// </summary>
        private class Line
        {
            public string Str;
            public Color ForeColor;

            public Line(string str, Color color)
            {
                Str = str;
                ForeColor = color;
            }
        };

        ArrayList lines = new ArrayList();

        Font origFont;
        Font monoFont;

        protected struct LegControlStruct
        {
            //private bool gLegStart;
            //private bool gCalfStart;
            //private bool gSoleStart;
            public bool GLegStart { get; set; }
            public bool GCalfStart { get; set; }
            public bool GSoleStart { get; set; }
        }

        protected LegControlStruct gLegCtl;
      
        public Form1()          //Constructor
        {
            InitializeComponent();

            //splitContainer1.FixedPanel = FixedPanel.Panel1;
            //splitContainer2.FixedPanel = FixedPanel.Panel2;

            outputList_Initialize();

            ComSetting.Read();
            TopMost = ComSetting.Option.StayOnTop;

            // let form use multiple fonts
            origFont = Font;
            FontFamily ff = new FontFamily("Courier New");
            monoFont = new Font(ff, 10, FontStyle.Regular);
            Font = ComSetting.Option.MonoFont ? monoFont : origFont;

            ComPort com = ComPort.Instance;
            com.StatusChanged += OnStatusChanged;
            com.DataReceived += OnDataReceived;
            com.Open();
        }

        // shutdown the worker thread when the form closes
        protected override void OnClosed(EventArgs e)
        {
            ComPort com = ComPort.Instance;
            com.Close();

            base.OnClosed(e);
        }

        /// <summary>
		/// output string to log file
		/// </summary>
		/// <param name="stringOut">string to output</param>
		public void logFile_writeLine(string stringOut)
        {
            if (ComSetting.Option.LogFileName != "")
            {
                Stream myStream = File.Open(ComSetting.Option.LogFileName,
                    FileMode.Append, FileAccess.Write, FileShare.Read);
                if (myStream != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream, Encoding.UTF8);
                    myWriter.WriteLine(stringOut);
                    myWriter.Close();
                }
            }
        }

        #region Output window
        string filterString = "";
        bool scrolling = true;
        Color receivedColor = Color.Green;
        Color sentColor = Color.Blue;

        /// <summary>
        /// context menu for the output window
        /// </summary>
        ContextMenu popUpMenu;

        /// <summary>
        /// check to see if filter matches string
        /// </summary>
        /// <param name="s">string to check</param>
        /// <returns>true if matches filter</returns>
        bool outputList_ApplyFilter(String s)
        {
            if (filterString == "")
            {
                return true;
            }
            else if (s == "")
            {
                return false;
            }
            else if (ComSetting.Option.FilterUseCase)
            {
                return (s.IndexOf(filterString) != -1);
            }
            else
            {
                string upperString = s.ToUpper();
                string upperFilter = filterString.ToUpper();
                return (upperString.IndexOf(upperFilter) != -1);
            }
        }

        /// <summary>
        /// clear the output window
        /// </summary>
        void outputList_ClearAll()
        {
            lines.Clear();
            partialLine = null;

            outputList.Items.Clear();
        }

        /// <summary>
        /// refresh the output window
        /// </summary>
        void outputList_Refresh()
        {
            outputList.BeginUpdate();
            outputList.Items.Clear();
            foreach (Line line in lines)
            {
                if (outputList_ApplyFilter(line.Str))
                {
                    outputList.Items.Add(line);
                }
            }
            outputList.EndUpdate();
            outputList_Scroll();
        }

        /// <summary>
        /// add a new line to output window
        /// </summary>
        Line outputList_Add(string str, Color color)
        {
            Line newLine = new Line(str, color);
            lines.Add(newLine);

            if (outputList_ApplyFilter(newLine.Str))
            {
                outputList.Items.Add(newLine);
                outputList_Scroll();
            }

            return newLine;
        }

        /// <summary>
        /// Update a line in the output window.
        /// </summary>
        /// <param name="line">line to update</param>
        void outputList_Update(Line line)
        {
            // should we add to output?
            if (outputList_ApplyFilter(line.Str))
            {
                // is the line already displayed?
                bool found = false;
                for (int i = 0; i < outputList.Items.Count; ++i)
                {
                    int index = (outputList.Items.Count - 1) - i;

                    if (line == outputList.Items[index])
                    {
                        // is item visible?
                        int itemsPerPage = (int)(outputList.Height / outputList.ItemHeight);
                        if (index >= outputList.TopIndex &&
                            index < (outputList.TopIndex + itemsPerPage))
                        {
                            // is there a way to refresh just one line
                            // without redrawing the entire listbox?
                            // changing the item value has no effect
                            outputList.Refresh();
                        }
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    // not found, so add it
                    outputList.Items.Add(line);
                }
            }
        }

        /// <summary>
        /// Initialize the output window
        /// </summary>
        private void outputList_Initialize()
        {
            // owner draw for listbox so we can add color
            outputList.DrawMode = DrawMode.OwnerDrawFixed;
            outputList.DrawItem += new DrawItemEventHandler(outputList_DrawItem);
            outputList.ClearSelected();

            // build the outputList context menu
            popUpMenu = new ContextMenu();
            popUpMenu.MenuItems.Add("&Copy", new EventHandler(outputList_Copy));
            popUpMenu.MenuItems[0].Visible = true;
            popUpMenu.MenuItems[0].Enabled = false;
            popUpMenu.MenuItems[0].Shortcut = Shortcut.CtrlC;
            popUpMenu.MenuItems[0].ShowShortcut = true;
            popUpMenu.MenuItems.Add("Copy All", new EventHandler(outputList_CopyAll));
            popUpMenu.MenuItems[1].Visible = true;
            popUpMenu.MenuItems.Add("Select &All", new EventHandler(outputList_SelectAll));
            popUpMenu.MenuItems[2].Visible = true;
            popUpMenu.MenuItems[2].Shortcut = Shortcut.CtrlA;
            popUpMenu.MenuItems[2].ShowShortcut = true;
            popUpMenu.MenuItems.Add("Clear Selected", new EventHandler(outputList_ClearSelected));
            popUpMenu.MenuItems[3].Visible = true;
            outputList.ContextMenu = popUpMenu;
        }

        /// <summary>
        /// draw item with color in output window
        /// </summary>
        void outputList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && e.Index < outputList.Items.Count)
            {
                Line line = (Line)outputList.Items[e.Index];

                // if selected, make the text color readable
                Color color = line.ForeColor;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    color = Color.Black;    // make it readable
                }

                e.Graphics.DrawString(line.Str, e.Font, new SolidBrush(color),
                    e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Scroll to bottom of output window
        /// </summary>
        void outputList_Scroll()
        {
            if (scrolling)
            {
                int itemsPerPage = (int)(outputList.Height / outputList.ItemHeight);
                outputList.TopIndex = outputList.Items.Count - itemsPerPage;
            }
        }

        /// <summary>
        /// Enable/Disable copy selection in output window
        /// </summary>
        private void outputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            popUpMenu.MenuItems[0].Enabled = (outputList.SelectedItems.Count > 0);
        }

        /// <summary>
        /// copy selection in output window to clipboard
        /// </summary>
        private void outputList_Copy(object sender, EventArgs e)
        {
            int iCount = outputList.SelectedItems.Count;
            if (iCount > 0)
            {
                String[] source = new String[iCount];
                for (int i = 0; i < iCount; ++i)
                {
                    source[i] = ((Line)outputList.SelectedItems[i]).Str;
                }

                String dest = String.Join("\r\n", source);
                Clipboard.SetText(dest);
            }
        }

        /// <summary>
        /// copy all lines in output window
        /// </summary>
        private void outputList_CopyAll(object sender, EventArgs e)
        {
            int iCount = outputList.Items.Count;
            if (iCount > 0)
            {
                String[] source = new String[iCount];
                for (int i = 0; i < iCount; ++i)
                {
                    source[i] = ((Line)outputList.Items[i]).Str;
                }

                String dest = String.Join("\r\n", source);
                Clipboard.SetText(dest);
            }
        }

        /// <summary>
        /// select all lines in output window
        /// </summary>
        private void outputList_SelectAll(object sender, EventArgs e)
        {
            outputList.BeginUpdate();
            for (int i = 0; i < outputList.Items.Count; ++i)
            {
                outputList.SetSelected(i, true);
            }
            outputList.EndUpdate();
        }

        /// <summary>
        /// clear selected in output window
        /// </summary>
        private void outputList_ClearSelected(object sender, EventArgs e)
        {
            outputList.ClearSelected();
            outputList.SelectedItem = -1;
        }
        #endregion


        #region Event handling - data received and status changed
        /// <summary>
        /// Prepare a string for output by converting non-printable characters.
        /// </summary>
        /// <param name="StringIn">input string to prepare.</param>
        /// <returns>output string.</returns>
        private String PrepareData(String StringIn)
        {
            // The names of the first 32 characters
            string[] charNames = { "NUL", "SOH", "STX", "ETX", "EOT",
                "ENQ", "ACK", "BEL", "BS", "TAB", "LF", "VT", "FF", "CR", "SO", "SI",
                "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB",
                "ESC", "FS", "GS", "RS", "US", "Space"};

            string StringOut = "";

            foreach (char c in StringIn)
            {
                if (ComSetting.Option.HexOutput)
                {
                    StringOut = StringOut + String.Format("{0:X2} ", (int)c);
                }
                else if (c < 32 && c != 9)
                {
                    StringOut = StringOut + "<" + charNames[c] + ">";

                    //Uglier "Termite" style
                    //StringOut = StringOut + String.Format("[{0:X2}]", (int)c);
                }
                else
                {
                    StringOut = StringOut + c;
                }
            }
            //StringOut += Environment.NewLine;
            return StringOut;
        }


        /// <summary>
        /// Partial line for AddData().
        /// </summary>
        private Line partialLine = null;

        /// <summary>
        /// Add data to the output.
        /// </summary>
        /// <param name="StringIn"></param>
        /// <returns></returns>
        private Line AddData(String StringIn)
        {
            String StringOut = PrepareData(StringIn);

            // if we have a partial line, add to it.
            if (partialLine != null)
            {
                // tack it on
                partialLine.Str = partialLine.Str + StringOut;
                outputList_Update(partialLine);
                return partialLine;
            }

            return outputList_Add(StringOut, receivedColor);
        }

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);

        /// <summary>
        /// Handle data received event from serial port.
        /// </summary>
        /// <param name="data">incoming data</param>
        public void OnDataReceived(string dataIn)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnDataReceived), new object[] { dataIn });
                //label3.Text = "1".ToString();
                return;
            }
            else
            {
                //label3.Text = "0".ToString();
            }

            // pause scrolling to speed up output of multiple lines
            bool saveScrolling = scrolling;
            scrolling = false;

            // if we detect a line terminator, add line to output
            int index;

            while(dataIn.Length > 0 &&
                ((index = dataIn.IndexOf("\r")) != -1 ||
                (index = dataIn.IndexOf("\n")) != -1))
            {
            
                String StringIn = dataIn.Substring(0, index);
                dataIn = dataIn.Remove(0, index + 1);

                logFile_writeLine(AddData(StringIn).Str);
                partialLine = null;	// terminate partial line
            }

            // if we have data remaining, add a partial line
            if (dataIn.Length > 0)
            {
                partialLine = AddData(dataIn);
            }

            // restore scrolling
            scrolling = saveScrolling;
            outputList_Scroll();
        }

        /// <summary>
        /// Update the connection status
        /// </summary>
        public void OnStatusChanged(string status)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }
            ComboPortList.Text = status;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.AutoScaleMode = AutoScaleMode.Inherit;

            this.outputList.Anchor = AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right;

            this.txtSend.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.txtSend.Multiline = false;
            this.txtSend.ReadOnly = false;

            btnOpen.Text = "connect".ToString();

            ComPort com = ComPort.Instance;

            Int32[] BaudRate = { 110, 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600, 0};

            //add port to ComboPortList
            int found = 0;

            string[] portList = com.GetAvailablePorts();

            for (int i = 0; i < portList.Length; i++)
            {
                string name = portList[i];
       
                ComboPortList.Items.Add(name);
                if (name == ComSetting.Port.PortName)
                    found = i;
            }

            if (portList.Length > 0)
            {
                ComboPortList.SelectedIndex = found;
            }

            //add baudrate to CobboBr
            found = 0;

            for (int i = 0; BaudRate[i] != 0; i++)
            {
                ComboBr.Items.Add(BaudRate[i].ToString());

                if (BaudRate[i] == ComSetting.Port.BaudRate)
                {
                    found = i;
                }
            }
            ComboBr.SelectedIndex = found;

            //Add DataBIt to Combobox
            ComboDb.Items.Add("5");
            ComboDb.Items.Add("6");
            ComboDb.Items.Add("7");
            ComboDb.Items.Add("8");
            ComboDb.SelectedIndex = ComSetting.Port.DataBits - 5;

            //add Parity to Combobox
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                ComboParity.Items.Add(s);
            }
            ComboParity.SelectedIndex = (int)ComSetting.Port.Parity;

            //add StopBIts to combobox
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                ComboSb.Items.Add(s);
            }
            ComboSb.SelectedIndex = (int)ComSetting.Port.StopBits;

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                ComboFlow.Items.Add(s);
            }
            ComboFlow.SelectedIndex = (int)ComSetting.Port.Handshake;

            switch (ComSetting.Option.AppendToSend)
            {
                case ComSetting.Option.AppendType.AppendNothing:
                    radioButton1.Checked = true;
                    break;
                case ComSetting.Option.AppendType.AppendCR:
                    radioButton2.Checked = true;
                    break;
                case ComSetting.Option.AppendType.AppendLF:
                    radioButton3.Checked = true;
                    break;
                case ComSetting.Option.AppendType.AppendCRLF:
                    radioButton4.Checked = true;
                    break;
            }
            checkBox1.Checked = ComSetting.Option.HexOutput;
            checkBox2.Checked = ComSetting.Option.MonoFont;
            checkBox3.Checked = ComSetting.Option.LocalEcho;
            checkBox4.Checked = ComSetting.Option.StayOnTop;
            checkBox5.Checked = ComSetting.Option.FilterUseCase;

            //textBox1.Text = ComSetting.Option.LogFileName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComPort com = ComPort.Instance;

            if (com.IsOpen)
            {
                com.Close();
                //com.Dispose();
                //com = null;
            }
        }

#region user_region
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ComSetting.Port.PortName = ComboPortList.Text;
            //MessageBox.Show(ComSetting.Port.PortName as string);
            ComSetting.Port.BaudRate = Int32.Parse(ComboBr.Text);
            //MessageBox.Show(ComSetting.Port.BaudRate.ToString());
            ComSetting.Port.DataBits = ComboDb.SelectedIndex + 5;
            //MessageBox.Show(ComSetting.Port.DataBits.ToString());
            ComSetting.Port.Parity = (Parity)ComboParity.SelectedIndex;
            //MessageBox.Show(ComSetting.Port.Parity.ToString());
            ComSetting.Port.StopBits = (StopBits)ComboSb.SelectedIndex;
            //MessageBox.Show(ComSetting.Port.StopBits.ToString());
            ComSetting.Port.Handshake = (Handshake)ComboFlow.SelectedIndex;

            ComPort com = ComPort.Instance;

            if (com.IsOpen)
            {
                com.Close();
                btnOpen.Text = "connect";
            }
            else
            {
                //com.StatusChanged += OnStatusChanged;
                //com.DataReceived += OnDataReceived;
                com.Open();
                outputList.Focus();
                btnOpen.Text = "disconnect";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ComPort com = ComPort.Instance;

            if (com.IsOpen)
            {
                com.Close();
                //com.Dispose();
                //com = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            outputList.Items.Clear();
            txtSend.Clear();
        }

        private void btnLegLength_Click(object sender, EventArgs e)
        {
            SerialPort sPort = new SerialPort();
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
#if false
                int iSendCount = 0;
                if (true == chkSndHexa.Checked)
                {
                    foreach (string s in txtSend.Text.Split(' '))
                    {
                        if (s != null && s != "")
                        {
                            byteSendData[iSendCount++] = Convert.ToByte(s, 16);
                        }
                    }
                sPort.Write(byteSendData, 0, iSendCount);
                }
                else
                {
                    sPort.Write(txtSend.Text);
                }
#endif
                ComPort com = ComPort.Instance;

                gLegCtl.GLegStart = !gLegCtl.GLegStart;
        
                if (gLegCtl.GLegStart)
                {
                      
                    bSendData = "leg lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxLegCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "leg lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);


                    tBoxLegCtl.Text = "stop".ToString();
                }             
            }
            catch (System.Exception ex)
            {
                gLegCtl.GLegStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
        }

        private void btnCalf_Click(object sender, EventArgs e)
        {
            SerialPort sPort = new SerialPort();
            ComPort com = ComPort.Instance;
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
                gLegCtl.GCalfStart = !gLegCtl.GCalfStart;

                if (gLegCtl.GCalfStart)
                {
                    bSendData = "calf lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxCalfCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "calf lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxCalfCtl.Text = "stop".ToString();
                }
            }
            catch (System.Exception ex)
            {
                gLegCtl.GCalfStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
        }

        private void btnSole_Click(object sender, EventArgs e)
        {
            SerialPort sPort = new SerialPort();
            byte[] byteSendData = new byte[100];
            string bSendData;

            try
            {
                gLegCtl.GSoleStart = !gLegCtl.GSoleStart;

                if (gLegCtl.GSoleStart)
                {
                    bSendData = "Sole lengh 1 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxSoleCtl.Text = "move".ToString();
                }
                else
                {
                    bSendData = "Sole lengh 0 100".ToString();
                    txtSend.Text = bSendData.ToString();

                    byteSendData = Encoding.ASCII.GetBytes(bSendData);
                    sPort.Write(byteSendData, 0, byteSendData.Length);

                    tBoxSoleCtl.Text = "stop".ToString();
                }
            }
            catch (System.Exception ex)
            {
                gLegCtl.GSoleStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
        }

        private void ComboPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComPort com = ComPort.Instance;

            if (com.IsOpen)
            {
                com.Close();
                //com.Dispose();
                //com = null;
            }
        }
    }
}
