﻿namespace Massage_Chair
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(1015, 19);
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
            this.lbComPort.Location = new System.Drawing.Point(38, 23);
            this.lbComPort.Name = "lbComPort";
            this.lbComPort.Size = new System.Drawing.Size(71, 15);
            this.lbComPort.TabIndex = 2;
            this.lbComPort.Text = "COM port";
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Location = new System.Drawing.Point(38, 63);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(70, 15);
            this.lbBaudRate.TabIndex = 3;
            this.lbBaudRate.Text = "Baud rate";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(416, 12);
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
            this.ComboPortList.Location = new System.Drawing.Point(147, 19);
            this.ComboPortList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboPortList.Name = "ComboPortList";
            this.ComboPortList.Size = new System.Drawing.Size(180, 23);
            this.ComboPortList.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(532, 12);
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
            this.txtSend.Location = new System.Drawing.Point(41, 276);
            this.txtSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ReadOnly = true;
            this.txtSend.Size = new System.Drawing.Size(1203, 29);
            this.txtSend.TabIndex = 13;
            // 
            // lbDataBit
            // 
            this.lbDataBit.AutoSize = true;
            this.lbDataBit.Location = new System.Drawing.Point(38, 103);
            this.lbDataBit.Name = "lbDataBit";
            this.lbDataBit.Size = new System.Drawing.Size(57, 15);
            this.lbDataBit.TabIndex = 14;
            this.lbDataBit.Text = "Data bit";
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.Location = new System.Drawing.Point(38, 143);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(44, 15);
            this.lbParity.TabIndex = 15;
            this.lbParity.Text = "Parity";
            // 
            // lbStopBit
            // 
            this.lbStopBit.AutoSize = true;
            this.lbStopBit.Location = new System.Drawing.Point(38, 183);
            this.lbStopBit.Name = "lbStopBit";
            this.lbStopBit.Size = new System.Drawing.Size(58, 15);
            this.lbStopBit.TabIndex = 16;
            this.lbStopBit.Text = "Stop bit";
            // 
            // lbSendMessage
            // 
            this.lbSendMessage.AutoSize = true;
            this.lbSendMessage.Location = new System.Drawing.Point(38, 257);
            this.lbSendMessage.Name = "lbSendMessage";
            this.lbSendMessage.Size = new System.Drawing.Size(105, 15);
            this.lbSendMessage.TabIndex = 20;
            this.lbSendMessage.Text = "Send message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Receive message";
            // 
            // ComboBr
            // 
            this.ComboBr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBr.FormattingEnabled = true;
            this.ComboBr.Location = new System.Drawing.Point(147, 59);
            this.ComboBr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBr.Name = "ComboBr";
            this.ComboBr.Size = new System.Drawing.Size(180, 23);
            this.ComboBr.TabIndex = 22;
            // 
            // ComboDb
            // 
            this.ComboDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDb.FormattingEnabled = true;
            this.ComboDb.Location = new System.Drawing.Point(147, 99);
            this.ComboDb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboDb.Name = "ComboDb";
            this.ComboDb.Size = new System.Drawing.Size(180, 23);
            this.ComboDb.TabIndex = 23;
            // 
            // ComboParity
            // 
            this.ComboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboParity.FormattingEnabled = true;
            this.ComboParity.Location = new System.Drawing.Point(147, 139);
            this.ComboParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboParity.Name = "ComboParity";
            this.ComboParity.Size = new System.Drawing.Size(180, 23);
            this.ComboParity.TabIndex = 24;
            // 
            // ComboSb
            // 
            this.ComboSb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSb.FormattingEnabled = true;
            this.ComboSb.Location = new System.Drawing.Point(147, 179);
            this.ComboSb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboSb.Name = "ComboSb";
            this.ComboSb.Size = new System.Drawing.Size(180, 23);
            this.ComboSb.TabIndex = 25;
            // 
            // ComboFlow
            // 
            this.ComboFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFlow.FormattingEnabled = true;
            this.ComboFlow.Location = new System.Drawing.Point(147, 219);
            this.ComboFlow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboFlow.Name = "ComboFlow";
            this.ComboFlow.Size = new System.Drawing.Size(180, 23);
            this.ComboFlow.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 223);
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
            this.groupBox2.Location = new System.Drawing.Point(703, 12);
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
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(41, 327);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1203, 174);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1256, 538);
            this.Controls.Add(this.richTextBox1);
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
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
