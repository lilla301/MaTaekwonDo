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
    public partial class addEsemeny : Form
    {
        esemenyNaptar en;
        public addEsemeny(esemenyNaptar en)
        {
            InitializeComponent();
            this.en = en;
        }

        internal esemenyNaptar getEsemeny()
        {
            return en;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxIdopont.TextLength != 0)
            {
                en.setIdopont(textBoxIdopont.Text);
            }
            else
            {
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(textBoxIdopont, "Érvénytelen bemenet");
            }
            
            if (textBoxEv.TextLength!=0)
            {
                en.setEv(Convert.ToInt32(textBoxEv.Text));
            }
            else
            {
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(textBoxEv, "Érvénytelen bemenet");
            }

            if (textBoxMegnevezes.TextLength != 0)
            {
                en.setMegnevezes(textBoxMegnevezes.Text);
            }
            else
            {
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(textBoxMegnevezes, "Érvénytelen bemenet");
            }
           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
