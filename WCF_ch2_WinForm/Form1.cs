using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF_ch2;
using WCF_ch2.Models;

namespace WCF_ch2_WinForm
{
    public partial class Form1 : Form
    {
        Service1 client = new Service1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = client.SelectDb(); 
            foreach (var item in data) { listBox1.Items.Add(item); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserModel userModel =new UserModel(0,textBox1.Text,textBox2.Text);
            client.POST(userModel);
        }
    }
}
