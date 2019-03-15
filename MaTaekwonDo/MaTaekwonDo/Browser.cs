using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaTaekwonDo
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== Convert.ToChar(Keys.Return))
            {
                webBrowser1.Navigate("http://taekwon-do.hu/");
            }
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.Text = "http://taekwon-do.hu/";
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://taekwon-do.hu/");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
