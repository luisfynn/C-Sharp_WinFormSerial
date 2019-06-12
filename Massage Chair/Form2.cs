using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Massage_Chair
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public delegate void TextEventHandler(string str);
        //public event TextEventHandler WriteTextEvent;

#if false
        private void button1_Click(object sender, EventArgs e)
        {
            WriteTextEvent(textBox1.Text);         // 등록된 이벤트를 통하여 Form1으로 데이터 전달   
        }
#endif

        public void received2(string str)
        {
            //this.textBox2.Text = str;
            //textBox2.Invalidate();
            switch(str)
            {
                case "1":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._1;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "2":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._2;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "3":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._3_1;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "4":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._4;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "5":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._5;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "6":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._6;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "7":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._7;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "8":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._8;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "9":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._9;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "10":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._10;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "11":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._11;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "12":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._12;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "13":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._13;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "14":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._14;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "15":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._15;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "16":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._16;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "17":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._17;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "18":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._18;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "19":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._19;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "20":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._20;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "21":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._21;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "22":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._22;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "23":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._23;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "24":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._24;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "25":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._25;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "26":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._26;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "27":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._27;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "28":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._28;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "29":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._29;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "30":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._30;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case "31":
                    //this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources._31;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;

                default:
                    this.pictureBox1.Show();
                    this.pictureBox1.Image = Properties.Resources.LIST;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
            }
           
        }
    }
}
