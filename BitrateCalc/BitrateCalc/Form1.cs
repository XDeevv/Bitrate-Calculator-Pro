using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitrateCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string monada;
        public double final;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                double minutes = Convert.ToDouble(textBox2.Text);
                double hours = Convert.ToDouble(textBox1.Text);


                if (textBox4.Enabled == false) 
                {
                    double qualitygbs = Convert.ToDouble(textBox3.Text);
                    double hoursmins = hours * 60;
                    double summins = hoursmins + minutes;
                    double quality = qualitygbs / 1024;

                    final = (summins * quality) * .0075;
                }
                else if (textBox4.Enabled == true)
                {
                    double hoursmins = hours * 60;
                    double summins = hoursmins + minutes;
                    double size = Convert.ToDouble(textBox4.Text);

                    final = size / (summins * .0075);
                }
                

                richTextBox1.Text = (final.ToString() + monada);

                if (checkBox1.Checked == true)
                {
                    //Copy it to clipboard
                    Clipboard.SetText(final.ToString());
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "ERROR!";
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox4.Enabled = false;
                monada = " GB";
            }
            else if (textBox4.Text == "")
            {
                textBox4.Enabled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                monada = " Kb/s";
                textBox3.Enabled = false;
            }
            else if (textBox3.Text == "")
            {
                textBox3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
Bitrate Calculator by vp10gr
version v1.0.0
");
        }
    }
}
