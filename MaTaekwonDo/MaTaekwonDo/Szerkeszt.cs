using MaTaekwonDo.Model;
using MaTaekwonDo.myException;
using MaTaekwonDo.Validation;
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
            textBoxEmail.Text = a.getEmail();
            textBoxKnev.Text = a.getKnev();
            textBoxPwd.Text = a.getPwd();
            textBoxVnev.Text = a.getVnev();
            comboBoxJog.Text = a.getCategoryId().ToString();
            comboBoxKlub.Text = a.getKlub().ToString();
            comboBoxNem.Text = a.getFiu();
            comboBoxOv.Text = a.getOvfok().ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public Adatok getModositottAdat()
        {
            return a;
        }
        private void buttonKesz_Click(object sender, EventArgs e)
        {
            a.setFnev(textBoxFnev.Text);
            a.setCategoryId(Convert.ToInt32(comboBoxJog.Text));
            a.setEmail(textBoxEmail.Text);
            a.setFiu(comboBoxNem.Text);
            a.setKlub(Convert.ToInt32(comboBoxKlub.Text));
            a.setKnev(textBoxKnev.Text);
            a.setOvfok(Convert.ToInt32(comboBoxOv.Text));
            a.setPwd(textBoxPwd.Text);
            a.setVnev(textBoxVnev.Text);

            try
            {
                NevEllenorzes ne = new NevEllenorzes(textBoxVnev.Text);
                ne.Ellenorzes();
            }
            catch(Exception ex)
            {
                throw new nevEllenorzoKivetel(ex.Message);
            }
            try
            {
                NevEllenorzes ne = new NevEllenorzes(textBoxKnev.Text);
                ne.Ellenorzes();
            }
            catch(Exception ex)
            {
                throw new nevEllenorzoKivetel(ex.Message);
            }

        }

        private void textBoxFnev_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void textBoxVnev_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
