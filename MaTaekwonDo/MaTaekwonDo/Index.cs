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
        Bejelentkezes b = new Bejelentkezes();

        public Index(string role)
        {
            InitializeComponent();
            buttonDig.Visible = false;
            buttonFelhKezelo.Visible = false;
            buttonLicense.Visible = false;
            buttonProfil.Visible = false;

            //buttonLogin.Visible = false;
            if (role == "1")
            {
                label5.Text = "admin";
                label6.Text = "Bejelentkezve, mint " + label5.Text;
                buttonDig.Visible = true;
                buttonFelhKezelo.Visible = true;
                buttonLicense.Visible = true;
                buttonProfil.Visible = true;

                //buttonLogin.Visible = false;
            }
            else if (role == "2")
            {
                label5.Text = "nagymester";
                label6.Text = "Bejelentkezve, mint " + label5.Text;
                buttonDig.Visible = true;
                buttonLicense.Visible = true;
                buttonProfil.Visible = true;

                //buttonLogin.Visible = false;
            }
            else
            {
                label5.Text = "felhasználó";
                label6.Text = "Bejelentkezve, mint " + label5.Text;
                buttonDig.Visible = true;
                buttonLicense.Visible = true;
                buttonProfil.Visible = true;

                //buttonLogin.Visible = false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        }

        private void buttonFelhKezelo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg nem elérhető");
        }
    }
}
