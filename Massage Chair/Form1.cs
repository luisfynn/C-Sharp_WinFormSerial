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
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace Massage_Chair
{
    public partial class Form1 : Form
    {
        const int btLocHeight = 410;
        const int btSizeWidth = 18;
        const int btSizeHeight = 22;
        const int btFirstX = 125;
        const int btInverval = 24;
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
        int rxCount = 0;
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

            //outputList_Initialize();

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

            //outputList.Items.Clear();
        }

        /// <summary>
        /// refresh the output window
        /// </summary>
        void outputList_Refresh()
        {
            //outputList.BeginUpdate();
            //outputList.Items.Clear();
            foreach (Line line in lines)
            {
                if (outputList_ApplyFilter(line.Str))
                {
                    //outputList.Items.Add(line);
                }
            }
            //outputList.EndUpdate();
           // outputList_Scroll();
        }

        /// <summary>
        /// add a new line to output window
        /// </summary>
        Line outputList_Add(string str, Color color)
        {
            Line newLine = new Line(str, color);
            /*
            lines.Add(newLine);

            if (outputList_ApplyFilter(newLine.Str))
            {
                //outputList.Items.Add(newLine);
                //outputList_Scroll();
            }
            */

            return newLine;
        }

        static int outputcount = 0;
        /// <summary>
        /// Update a line in the output window.
        /// </summary>
        /// <param name="line">line to update</param>
        void outputList_Update(Line line)
        {
            outputcount++;

            //outputList.Items.Add(line.Str);
            //outputList.Text += line.Str;
            var replace = line.Str.Replace("24 41 52", Environment.NewLine + "24 41 52");

            if(outputcount > 100)
            {
                outputcount = 0;
                richTextBox1.Text = " ";
            }
            else
            {
                richTextBox1.Text = " ";
                richTextBox1.AppendText(replace);
            }
  
            //richTextBox1.Text = replace;
#if false
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
#endif
        }

#if false
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
#endif
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
                //rxCount++;

                // tack it on
                if (rxCount >= 50)
                {
                    rxCount = 0;
                    partialLine.Str = StringOut;
                }
                else
                {            
                    partialLine.Str = partialLine.Str + StringOut;
                }
             
                outputList_Update(partialLine);

                //ComPort com = ComPort.Instance;
                //com.DiscardInBuffer();

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

            //ComPort com = ComPort.Instance;
            //com.DiscardInBuffer();

            // restore scrolling
            scrolling = saveScrolling;
            outputList_Scroll();
        }

        /// <summary>
        /// Scroll to bottom of output window
        /// </summary>
        void outputList_Scroll()
        {
            if (scrolling)
            {
                richTextBox1.ScrollToCaret();
                // itemsPerPage = (int)(richTextBox1.Height / outputList.ItemHeight);
                //outputList.TopIndex = outputList.Items.Count - itemsPerPage;
            }
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
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.AutoScaleMode = AutoScaleMode.Inherit;

            this.richTextBox1.Anchor = AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right;
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.BorderStyle = BorderStyle.FixedSingle;

            this.txtSend.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.txtSend.Multiline = false;
            this.txtSend.ReadOnly = false;

            //this.pictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button5.Click += new System.EventHandler(this.button5_Click);

            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button10.Click += new System.EventHandler(this.button10_Click);

            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button12.Click += new System.EventHandler(this.button12_Click);
            this.button13.Click += new System.EventHandler(this.button13_Click);
            this.button14.Click += new System.EventHandler(this.button14_Click);
            this.button15.Click += new System.EventHandler(this.button15_Click);

            this.button16.Click += new System.EventHandler(this.button16_Click);
            this.button17.Click += new System.EventHandler(this.button17_Click);
            this.button18.Click += new System.EventHandler(this.button18_Click);
            this.button19.Click += new System.EventHandler(this.button19_Click);
            this.button20.Click += new System.EventHandler(this.button20_Click);

            this.button21.Click += new System.EventHandler(this.button21_Click);
            this.button22.Click += new System.EventHandler(this.button22_Click);
            this.button23.Click += new System.EventHandler(this.button23_Click);
            this.button24.Click += new System.EventHandler(this.button24_Click);
            this.button25.Click += new System.EventHandler(this.button25_Click);

            this.button26.Click += new System.EventHandler(this.button26_Click);
            this.button27.Click += new System.EventHandler(this.button27_Click);
            this.button28.Click += new System.EventHandler(this.button28_Click);
            this.button29.Click += new System.EventHandler(this.button29_Click);
            this.button30.Click += new System.EventHandler(this.button30_Click);

            this.button31.Click += new System.EventHandler(this.button31_Click);
            this.button32.Click += new System.EventHandler(this.button32_Click);

            this.button1.Size = new Size(btSizeWidth, btSizeHeight);
            this.button2.Size = new Size(btSizeWidth, btSizeHeight);
            this.button3.Size = new Size(btSizeWidth, btSizeHeight);
            this.button4.Size = new Size(btSizeWidth, btSizeHeight);
            this.button5.Size = new Size(btSizeWidth, btSizeHeight);

            this.button6.Size = new Size(btSizeWidth, btSizeHeight);
            this.button7.Size = new Size(btSizeWidth, btSizeHeight);
            this.button8.Size = new Size(btSizeWidth, btSizeHeight);
            this.button9.Size = new Size(btSizeWidth, btSizeHeight);
            this.button10.Size = new Size(btSizeWidth, btSizeHeight);

            this.button11.Size = new Size(btSizeWidth, btSizeHeight);
            this.button12.Size = new Size(btSizeWidth, btSizeHeight);
            this.button13.Size = new Size(btSizeWidth, btSizeHeight);
            this.button14.Size = new Size(btSizeWidth, btSizeHeight);
            this.button15.Size = new Size(btSizeWidth, btSizeHeight);

            this.button16.Size = new Size(btSizeWidth, btSizeHeight);
            this.button17.Size = new Size(btSizeWidth, btSizeHeight);
            this.button18.Size = new Size(btSizeWidth, btSizeHeight);
            this.button19.Size = new Size(btSizeWidth, btSizeHeight);
            this.button20.Size = new Size(btSizeWidth, btSizeHeight);

            this.button21.Size = new Size(btSizeWidth, btSizeHeight);
            this.button22.Size = new Size(btSizeWidth, btSizeHeight);
            this.button23.Size = new Size(btSizeWidth, btSizeHeight);
            this.button24.Size = new Size(btSizeWidth, btSizeHeight);
            this.button25.Size = new Size(btSizeWidth, btSizeHeight);

            this.button26.Size = new Size(btSizeWidth, btSizeHeight);
            this.button27.Size = new Size(btSizeWidth, btSizeHeight);
            this.button28.Size = new Size(btSizeWidth, btSizeHeight);
            this.button29.Size = new Size(btSizeWidth, btSizeHeight);
            this.button30.Size = new Size(btSizeWidth, btSizeHeight);

            this.button31.Size = new Size(btSizeWidth, btSizeHeight);
            this.button32.Size = new Size(btSizeWidth, btSizeHeight);

            this.button1.Location = new Point(btFirstX, btLocHeight);
            this.button2.Location = new Point(btFirstX + btInverval, btLocHeight);
            this.button3.Location = new Point(btFirstX + btInverval * 2, btLocHeight);
            this.button4.Location = new Point(btFirstX + btInverval * 3, btLocHeight);
            this.button5.Location = new Point(btFirstX + btInverval * 4, btLocHeight);
            this.button6.Location = new Point(btFirstX + btInverval * 5, btLocHeight);
            this.button7.Location = new Point(btFirstX + btInverval * 6, btLocHeight);
            this.button8.Location = new Point(btFirstX + btInverval * 7, btLocHeight);
            this.button9.Location = new Point(btFirstX + btInverval * 8, btLocHeight);
            this.button10.Location = new Point(btFirstX + btInverval * 9, btLocHeight);

            this.button11.Location = new Point(btFirstX + btInverval * 10, btLocHeight);
            this.button12.Location = new Point(btFirstX + btInverval * 11, btLocHeight);
            this.button13.Location = new Point(btFirstX + btInverval * 12, btLocHeight);
            this.button14.Location = new Point(btFirstX + btInverval * 13, btLocHeight);
            this.button15.Location = new Point(btFirstX + btInverval * 14, btLocHeight);
            this.button16.Location = new Point(btFirstX + btInverval * 15, btLocHeight);
            this.button17.Location = new Point(btFirstX + btInverval * 16, btLocHeight);
            this.button18.Location = new Point(btFirstX + btInverval * 17, btLocHeight);
            this.button19.Location = new Point(btFirstX + btInverval * 18, btLocHeight);
            this.button20.Location = new Point(btFirstX + btInverval * 19, btLocHeight);

            this.button21.Location = new Point(btFirstX + btInverval * 20, btLocHeight);
            this.button22.Location = new Point(btFirstX + btInverval * 21, btLocHeight);
            this.button23.Location = new Point(btFirstX + btInverval * 22, btLocHeight);
            this.button24.Location = new Point(btFirstX + btInverval * 23, btLocHeight);
            this.button25.Location = new Point(btFirstX + btInverval * 24, btLocHeight);
            this.button26.Location = new Point(btFirstX + btInverval * 25, btLocHeight);
            this.button27.Location = new Point(btFirstX + btInverval * 26, btLocHeight);
            this.button28.Location = new Point(btFirstX + btInverval * 27, btLocHeight);
            this.button29.Location = new Point(btFirstX + btInverval * 28, btLocHeight);
            this.button30.Location = new Point(btFirstX + btInverval * 29, btLocHeight);

            this.button31.Location = new Point(btFirstX + btInverval * 30, btLocHeight);
            this.button32.Location = new Point(btFirstX - btInverval , btLocHeight);

            this.button1.Text = "1";
            this.button2.Text = "2";
            this.button3.Text = "3";
            this.button4.Text = "4";
            this.button5.Text = "5";
            this.button6.Text = "6";
            this.button7.Text = "7";
            this.button8.Text = "8";
            this.button9.Text = "9";
            this.button10.Text = "0";

            this.button11.Text = "1";
            this.button12.Text = "2";
            this.button13.Text = "3";
            this.button14.Text = "4";
            this.button15.Text = "5";
            this.button16.Text = "6";
            this.button17.Text = "7";
            this.button18.Text = "8";
            this.button19.Text = "9";
            this.button20.Text = "0";

            this.button21.Text = "1";
            this.button22.Text = "2";
            this.button23.Text = "3";
            this.button24.Text = "4";
            this.button25.Text = "5";
            this.button26.Text = "6";
            this.button27.Text = "7";
            this.button28.Text = "8";
            this.button29.Text = "9";
            this.button30.Text = "0";

            this.button31.Text = "1";

            this.button32.Text = "L";

            this.button1.Font = new Font("굴림", 7F);
            this.button2.Font = new Font("굴림", 7F);
            this.button3.Font = new Font("굴림", 7F);
            this.button4.Font = new Font("굴림", 7F);
            this.button5.Font = new Font("굴림", 7F);

            this.button6.Font = new Font("굴림", 7F);
            this.button7.Font = new Font("굴림", 7F);
            this.button8.Font = new Font("굴림", 7F);
            this.button9.Font = new Font("굴림", 7F);
            this.button10.Font = new Font("굴림", 7F);

            this.button11.Font = new Font("굴림", 7F);
            this.button12.Font = new Font("굴림", 7F);
            this.button13.Font = new Font("굴림", 7F);
            this.button14.Font = new Font("굴림", 7F);
            this.button15.Font = new Font("굴림", 7F);

            this.button16.Font = new Font("굴림", 7F);
            this.button17.Font = new Font("굴림", 7F);
            this.button18.Font = new Font("굴림", 7F);
            this.button19.Font = new Font("굴림", 7F);
            this.button20.Font = new Font("굴림", 7F);

            this.button21.Font = new Font("굴림", 7F);
            this.button22.Font = new Font("굴림", 7F);
            this.button23.Font = new Font("굴림", 7F);
            this.button24.Font = new Font("굴림", 7F);
            this.button25.Font = new Font("굴림", 7F);

            this.button26.Font = new Font("굴림", 7F);
            this.button27.Font = new Font("굴림", 7F);
            this.button28.Font = new Font("굴림", 7F);
            this.button29.Font = new Font("굴림", 7F);
            this.button30.Font = new Font("굴림", 7F);

            this.button31.Font = new Font("굴림", 7F);
            this.button32.Font = new Font("굴림", 7F);
#if false
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox3.Checked = true;

            this.checkBox1.CheckState = CheckState.Checked;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox3.CheckState = CheckState.Checked;
#endif
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

            if (radioButton2.Checked)
                ComSetting.Option.AppendToSend = ComSetting.Option.AppendType.AppendCR;
            else if (radioButton3.Checked)
                ComSetting.Option.AppendToSend = ComSetting.Option.AppendType.AppendLF;
            else if (radioButton4.Checked)
                ComSetting.Option.AppendToSend = ComSetting.Option.AppendType.AppendCRLF;
            else
                ComSetting.Option.AppendToSend = ComSetting.Option.AppendType.AppendNothing;

            ComSetting.Option.HexOutput = checkBox1.Checked;
            ComSetting.Option.MonoFont = checkBox2.Checked;
            ComSetting.Option.LocalEcho = checkBox3.Checked;
            ComSetting.Option.StayOnTop = checkBox4.Checked;
            ComSetting.Option.FilterUseCase = checkBox5.Checked;

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
                richTextBox1.Focus();
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
            outputList_ClearAll();
            richTextBox1.Clear();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                gLegCtl.GSoleStart = false;
                txtSend.Clear();
                MessageBox.Show("serial port를 연결해주세요");
            }
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

#if true
        void frm2_WriteTextEvent(string text, EventArgs e)
        {
            //this.textBox2.Text = text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.pictureBox1.Show();
            //this.pictureBox1.Image = Properties.Resources._1;
            //this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            Form2 picture = new Form2();
            picture.Show();
            //frm2.WriteTextEvent += new Form2.TextEventHandler(frm2_WriteTextEvent);  // 델리게이트를 통한 이벤트 등록
            picture.received2(button1.Text); //Form2로 데이터 전달
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.pictureBox1.Show();
            //this.pictureBox1.Image = Properties.Resources._2;
            //this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button2.Text); //Form2로 데이터 전달
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button3.Text); //Form2로 데이터 전달
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button4.Text); //Form2로 데이터 전달
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button5.Text); //Form2로 데이터 전달
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button6.Text); //Form2로 데이터 전달
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button7.Text); //Form2로 데이터 전달
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button8.Text); //Form2로 데이터 전달
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button9.Text); //Form2로 데이터 전달
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2("1" + button10.Text); //Form2로 데이터 전달
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button11.Text); //Form2로 데이터 전달
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button12.Text); //Form2로 데이터 전달
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button13.Text); //Form2로 데이터 전달
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button14.Text); //Form2로 데이터 전달
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button15.Text); //Form2로 데이터 전달
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button16.Text); //Form2로 데이터 전달
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button17.Text); //Form2로 데이터 전달
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button18.Text); //Form2로 데이터 전달
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button19.Text); //Form2로 데이터 전달
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2("2" + button20.Text); //Form2로 데이터 전달
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button21.Text); //Form2로 데이터 전달
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button22.Text); //Form2로 데이터 전달
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button23.Text); //Form2로 데이터 전달
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button24.Text); //Form2로 데이터 전달
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button25.Text); //Form2로 데이터 전달
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button26.Text); //Form2로 데이터 전달
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button27.Text); //Form2로 데이터 전달
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button28.Text); //Form2로 데이터 전달
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button29.Text); //Form2로 데이터 전달
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2("3" + button30.Text); //Form2로 데이터 전달
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button31.Text); //Form2로 데이터 전달
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Form2 picture = new Form2();
            picture.Show();
            picture.received2(button32.Text); //Form2로 데이터 전달
        }
#endif
    }
}
