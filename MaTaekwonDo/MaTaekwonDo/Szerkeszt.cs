using MaTaekwonDo.Model;
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
    public partial class Szerkeszt : Form
    {
        private Adatok a;
        public Szerkeszt(Adatok a)
        {
           
            InitializeComponent();
            a = new Adatok();
            this.a = a;
            textBoxFnev.Text = a.getfnev();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public Adatok getAdat()
        {
            return a;
        }
        private void buttonKesz_Click(object sender, EventArgs e)
        {
            a.setFnev(textBoxFnev.Text);
        }
    }
}
