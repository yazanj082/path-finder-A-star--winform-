using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        [STAThread]
        private void button1_Click(object sender, EventArgs e)
        {
            int width, height;
            try
            {
                
                width = Int32.Parse(textBox1.Text);
                height = Int32.Parse(textBox2.Text);
                if(width>15 || width < 4) { throw new Exception(); }
                if (height > 15 || height < 4) { throw new Exception(); }
                Form2 f2=new Form2(width,height);
                this.Hide();
                f2.Show();
            }
            catch(Exception ex)
            {
                label6.Text = "enter values between 4 and 15";
            }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
