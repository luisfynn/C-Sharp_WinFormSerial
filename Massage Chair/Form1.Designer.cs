namespace Massage_Chair
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLegLength = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxAirCtl = new System.Windows.Forms.TextBox();
            this.tBoxSoleCtl = new System.Windows.Forms.TextBox();
            this.tBoxCalfCtl = new System.Windows.Forms.TextBox();
            this.tBoxLegCtl = new System.Windows.Forms.TextBox();
            this.btnAir = new System.Windows.Forms.Button();
            this.btnSole = new System.Windows.Forms.Button();
            this.btnCalf = new System.Windows.Forms.Button();
            this.lbComPort = new System.Windows.Forms.Label();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.ComboPortList = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.lbDataBit = new System.Windows.Forms.Label();
            this.lbParity = new System.Windows.Forms.Label();
            this.lbStopBit = new System.Windows.Forms.Label();
            this.lbSendMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBr = new System.Windows.Forms.ComboBox();
            this.ComboDb = new System.Windows.Forms.ComboBox();
            this.ComboParity = new System.Windows.Forms.ComboBox();
            this.ComboSb = new System.Windows.Forms.ComboBox();
            this.ComboFlow = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLegLength
            // 
            this.btnLegLength.Location = new System.Drawing.Point(7, 25);
            this.btnLegLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLegLength.Name = "btnLegLength";
            this.btnLegLength.Size = new System.Drawing.Size(133, 29);
            this.btnLegLength.TabIndex = 0;
            this.btnLegLength.Text = "LegLengthMotor";
            this.btnLegLength.UseVisualStyleBackColor = true;
            this.btnLegLength.Click += new System.EventHandler(this.btnLegLength_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxAirCtl);
            this.groupBox1.Controls.Add(this.tBoxSoleCtl);
            this.groupBox1.Controls.Add(this.tBoxCalfCtl);
            this.groupBox1.Controls.Add(this.tBoxLegCtl);
            this.groupBox1.Controls.Add(this.btnAir);
            this.groupBox1.Controls.Add(this.btnSole);
            this.groupBox1.Controls.Add(this.btnCalf);
            this.groupBox1.Controls.Add(this.btnLegLength);
            this.groupBox1.Location = new System.Drawing.Point(992, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(229, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LegMassage Block";
            // 
            // tBoxAirCtl
            // 
            this.tBoxAirCtl.Location = new System.Drawing.Point(146, 136);
            this.tBoxAirCtl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxAirCtl.Name = "tBoxAirCtl";
            this.tBoxAirCtl.ReadOnly = true;
            this.tBoxAirCtl.Size = new System.Drawing.Size(75, 25);
            this.tBoxAirCtl.TabIndex = 25;
            // 
            // tBoxSoleCtl
            // 
            this.tBoxSoleCtl.Location = new System.Drawing.Point(146, 100);
            this.tBoxSoleCtl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxSoleCtl.Name = "tBoxSoleCtl";
            this.tBoxSoleCtl.ReadOnly = true;
            this.tBoxSoleCtl.Size = new System.Drawing.Size(75, 25);
            this.tBoxSoleCtl.TabIndex = 24;
            // 
            // tBoxCalfCtl
            // 
            this.tBoxCalfCtl.Location = new System.Drawing.Point(146, 64);
            this.tBoxCalfCtl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxCalfCtl.Name = "tBoxCalfCtl";
            this.tBoxCalfCtl.ReadOnly = true;
            this.tBoxCalfCtl.Size = new System.Drawing.Size(75, 25);
            this.tBoxCalfCtl.TabIndex = 23;
            // 
            // tBoxLegCtl
            // 
            this.tBoxLegCtl.Location = new System.Drawing.Point(146, 25);
            this.tBoxLegCtl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxLegCtl.Name = "tBoxLegCtl";
            this.tBoxLegCtl.ReadOnly = true;
            this.tBoxLegCtl.Size = new System.Drawing.Size(75, 25);
            this.tBoxLegCtl.TabIndex = 22;
            // 
            // btnAir
            // 
            this.btnAir.Location = new System.Drawing.Point(7, 134);
            this.btnAir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAir.Name = "btnAir";
            this.btnAir.Size = new System.Drawing.Size(133, 29);
            this.btnAir.TabIndex = 3;
            this.btnAir.Text = "Air pocket";
            this.btnAir.UseVisualStyleBackColor = true;
            // 
            // btnSole
            // 
            this.btnSole.Location = new System.Drawing.Point(7, 98);
            this.btnSole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSole.Name = "btnSole";
            this.btnSole.Size = new System.Drawing.Size(133, 29);
            this.btnSole.TabIndex = 2;
            this.btnSole.Text = "SoleMotor";
            this.btnSole.UseVisualStyleBackColor = true;
            this.btnSole.Click += new System.EventHandler(this.btnSole_Click);
            // 
            // btnCalf
            // 
            this.btnCalf.Location = new System.Drawing.Point(7, 61);
            this.btnCalf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCalf.Name = "btnCalf";
            this.btnCalf.Size = new System.Drawing.Size(133, 29);
            this.btnCalf.TabIndex = 1;
            this.btnCalf.Text = "CalfMotor";
            this.btnCalf.UseVisualStyleBackColor = true;
            this.btnCalf.Click += new System.EventHandler(this.btnCalf_Click);
            // 
            // lbComPort
            // 
            this.lbComPort.AutoSize = true;
            this.lbComPort.Location = new System.Drawing.Point(15, 41);
            this.lbComPort.Name = "lbComPort";
            this.lbComPort.Size = new System.Drawing.Size(71, 15);
            this.lbComPort.TabIndex = 2;
            this.lbComPort.Text = "COM port";
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Location = new System.Drawing.Point(15, 81);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(70, 15);
            this.lbBaudRate.TabIndex = 3;
            this.lbBaudRate.Text = "Baud rate";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(393, 37);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(110, 29);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Connect";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ComboPortList
            // 
            this.ComboPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboPortList.FormattingEnabled = true;
            this.ComboPortList.Location = new System.Drawing.Point(124, 37);
            this.ComboPortList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboPortList.Name = "ComboPortList";
            this.ComboPortList.Size = new System.Drawing.Size(180, 23);
            this.ComboPortList.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(509, 37);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 29);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Message Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(3, 294);
            this.txtSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ReadOnly = true;
            this.txtSend.Size = new System.Drawing.Size(1218, 29);
            this.txtSend.TabIndex = 13;
            // 
            // lbDataBit
            // 
            this.lbDataBit.AutoSize = true;
            this.lbDataBit.Location = new System.Drawing.Point(15, 121);
            this.lbDataBit.Name = "lbDataBit";
            this.lbDataBit.Size = new System.Drawing.Size(57, 15);
            this.lbDataBit.TabIndex = 14;
            this.lbDataBit.Text = "Data bit";
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.Location = new System.Drawing.Point(15, 161);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(44, 15);
            this.lbParity.TabIndex = 15;
            this.lbParity.Text = "Parity";
            // 
            // lbStopBit
            // 
            this.lbStopBit.AutoSize = true;
            this.lbStopBit.Location = new System.Drawing.Point(15, 201);
            this.lbStopBit.Name = "lbStopBit";
            this.lbStopBit.Size = new System.Drawing.Size(58, 15);
            this.lbStopBit.TabIndex = 16;
            this.lbStopBit.Text = "Stop bit";
            // 
            // lbSendMessage
            // 
            this.lbSendMessage.AutoSize = true;
            this.lbSendMessage.Location = new System.Drawing.Point(7, 275);
            this.lbSendMessage.Name = "lbSendMessage";
            this.lbSendMessage.Size = new System.Drawing.Size(105, 15);
            this.lbSendMessage.TabIndex = 20;
            this.lbSendMessage.Text = "Send message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Receive message";
            // 
            // ComboBr
            // 
            this.ComboBr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBr.FormattingEnabled = true;
            this.ComboBr.Location = new System.Drawing.Point(124, 77);
            this.ComboBr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBr.Name = "ComboBr";
            this.ComboBr.Size = new System.Drawing.Size(180, 23);
            this.ComboBr.TabIndex = 22;
            // 
            // ComboDb
            // 
            this.ComboDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDb.FormattingEnabled = true;
            this.ComboDb.Location = new System.Drawing.Point(124, 117);
            this.ComboDb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboDb.Name = "ComboDb";
            this.ComboDb.Size = new System.Drawing.Size(180, 23);
            this.ComboDb.TabIndex = 23;
            // 
            // ComboParity
            // 
            this.ComboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboParity.FormattingEnabled = true;
            this.ComboParity.Location = new System.Drawing.Point(124, 157);
            this.ComboParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboParity.Name = "ComboParity";
            this.ComboParity.Size = new System.Drawing.Size(180, 23);
            this.ComboParity.TabIndex = 24;
            // 
            // ComboSb
            // 
            this.ComboSb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSb.FormattingEnabled = true;
            this.ComboSb.Location = new System.Drawing.Point(124, 197);
            this.ComboSb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboSb.Name = "ComboSb";
            this.ComboSb.Size = new System.Drawing.Size(180, 23);
            this.ComboSb.TabIndex = 25;
            // 
            // ComboFlow
            // 
            this.ComboFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFlow.FormattingEnabled = true;
            this.ComboFlow.Location = new System.Drawing.Point(124, 237);
            this.ComboFlow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboFlow.Name = "ComboFlow";
            this.ComboFlow.Size = new System.Drawing.Size(180, 23);
            this.ComboFlow.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Flow Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(680, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(243, 223);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 118);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Hex output";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(20, 196);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(159, 19);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Filter case sensitive";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(20, 177);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(107, 19);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Stay on top";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(20, 157);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(103, 19);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Local echo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(20, 137);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(145, 19);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Monospaced font";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(20, 84);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(126, 19);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Append CR-LF";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(20, 63);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(98, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Append LF";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 43);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Append CR";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 22);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(130, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Append nothing";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 7F);
            this.button1.Location = new System.Drawing.Point(181, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(181, 384);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 384);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 40;
            this.button5.Text = "8";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(181, 384);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 39;
            this.button6.Text = "7";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(181, 384);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 38;
            this.button7.Text = "6";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(181, 384);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 37;
            this.button8.Text = "5";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(181, 384);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(23, 23);
            this.button9.TabIndex = 46;
            this.button9.Text = "14";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(181, 384);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(23, 23);
            this.button10.TabIndex = 45;
            this.button10.Text = "13";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(181, 384);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(23, 23);
            this.button11.TabIndex = 44;
            this.button11.Text = "12";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(181, 384);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(23, 23);
            this.button12.TabIndex = 43;
            this.button12.Text = "11";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(181, 384);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(23, 23);
            this.button13.TabIndex = 42;
            this.button13.Text = "10";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(181, 384);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(23, 23);
            this.button14.TabIndex = 41;
            this.button14.Text = "9";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(181, 384);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(23, 23);
            this.button15.TabIndex = 52;
            this.button15.Text = "20";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(181, 384);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(23, 23);
            this.button16.TabIndex = 51;
            this.button16.Text = "19";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(181, 384);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(23, 23);
            this.button17.TabIndex = 50;
            this.button17.Text = "18";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(181, 384);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(23, 23);
            this.button18.TabIndex = 49;
            this.button18.Text = "17";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(181, 384);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(23, 23);
            this.button19.TabIndex = 48;
            this.button19.Text = "16";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(181, 384);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(23, 23);
            this.button20.TabIndex = 47;
            this.button20.Text = "15";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(181, 384);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(23, 23);
            this.button21.TabIndex = 58;
            this.button21.Text = "26";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(181, 384);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(23, 23);
            this.button22.TabIndex = 57;
            this.button22.Text = "25";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(181, 384);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(23, 23);
            this.button23.TabIndex = 56;
            this.button23.Text = "24";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(181, 384);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(23, 23);
            this.button24.TabIndex = 55;
            this.button24.Text = "23";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(181, 384);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(23, 23);
            this.button25.TabIndex = 54;
            this.button25.Text = "22";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(181, 384);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(23, 23);
            this.button26.TabIndex = 53;
            this.button26.Text = "21";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(3, 428);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(928, 450);
            this.richTextBox1.TabIndex = 59;
            this.richTextBox1.Text = "";
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(181, 384);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(23, 23);
            this.button27.TabIndex = 64;
            this.button27.Text = "26";
            this.button27.UseVisualStyleBackColor = true;
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(181, 384);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(23, 23);
            this.button28.TabIndex = 63;
            this.button28.Text = "25";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(181, 384);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(23, 23);
            this.button29.TabIndex = 62;
            this.button29.Text = "24";
            this.button29.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(181, 384);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(23, 23);
            this.button30.TabIndex = 61;
            this.button30.Text = "23";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(181, 384);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(23, 23);
            this.button31.TabIndex = 60;
            this.button31.Text = "22";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(10, 382);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(26, 23);
            this.button32.TabIndex = 65;
            this.button32.Text = "button32";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Massage_Chair.Properties.Resources.LIST2;
            this.pictureBox1.Location = new System.Drawing.Point(937, 428);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 360);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1290, 842);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ComboFlow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboSb);
            this.Controls.Add(this.ComboParity);
            this.Controls.Add(this.ComboDb);
            this.Controls.Add(this.ComboBr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSendMessage);
            this.Controls.Add(this.lbStopBit);
            this.Controls.Add(this.lbParity);
            this.Controls.Add(this.lbDataBit);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ComboPortList);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lbBaudRate);
            this.Controls.Add(this.lbComPort);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Serial Test Program V0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLegLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSole;
        private System.Windows.Forms.Button btnCalf;
        private System.Windows.Forms.Label lbComPort;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label lbDataBit;
        private System.Windows.Forms.Label lbParity;
        private System.Windows.Forms.Label lbStopBit;
        private System.Windows.Forms.Label lbSendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAir;
        private System.Windows.Forms.TextBox tBoxAirCtl;
        private System.Windows.Forms.TextBox tBoxSoleCtl;
        private System.Windows.Forms.TextBox tBoxCalfCtl;
        private System.Windows.Forms.TextBox tBoxLegCtl;
        protected System.Windows.Forms.ComboBox ComboPortList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        protected System.Windows.Forms.ComboBox ComboBr;
        protected System.Windows.Forms.ComboBox ComboParity;
        protected System.Windows.Forms.ComboBox ComboDb;
        protected System.Windows.Forms.ComboBox ComboSb;
        protected System.Windows.Forms.ComboBox ComboFlow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

