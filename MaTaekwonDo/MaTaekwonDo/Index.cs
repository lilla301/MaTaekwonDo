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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Bejelentkezes b = new Bejelentkezes();
            //b.Show();
            this.Hide();
        }

        private void buttonWebOldal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg nem elérhető");
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg nem elérhető");
        }

        private void buttonProfil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg nem elérhető");
        }

        private void Index_Load(object sender, EventArgs e)
        {
            toolTipLogin.SetToolTip(buttonDig, "Digitális Anyag");
            toolTipLogin.SetToolTip(buttonExit, "A program bezárása");
            toolTipLogin.SetToolTip(buttonLogin, "Bejelentkezés");
            toolTipLogin.SetToolTip(buttonLicense, "Az alkotóról");
            toolTipLogin.SetToolTip(buttonWebOldal, "A hivatalos weboldal");
            toolTipLogin.SetToolTip(buttonProfil, "Felhasználói profil");
            toolTipLogin.SetToolTip(buttonFelhKezelo, "Felhasználók kezelése");
            buttonDig.Visible = false;
            buttonFelhKezelo.Visible = false;
            buttonLicense.Visible = false;
            buttonProfil.Visible = false;

        }

        private void buttonFelhKezelo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg nem elérhető");
        }
    }
}
