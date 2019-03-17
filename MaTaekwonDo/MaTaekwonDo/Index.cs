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
        private string kerNev;
        private int catId;

        public Index(int catId,string kerNev)
        {
            InitializeComponent();
            this.kerNev = kerNev;
            this.catId = catId;
            buttonDig.Visible = false;
            buttonFelhKezelo.Visible = false;
            buttonLicense.Visible = false;
            buttonProfil.Visible = false;

            //buttonLogin.Visible = false;
            if (catId == 1)
            {
                label5.Text = "admin";
                label6.Text = "Bejelentkezve, mint " + label5.Text;
                buttonDig.Visible = true;
                buttonFelhKezelo.Visible = true;
                buttonLicense.Visible = true;
                buttonProfil.Visible = true;

                //buttonLogin.Visible = false;
            }
            else if (catId == 2)
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
            Browser b = new Browser();
            this.Hide();
            if (b.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                b.Dispose();
            }
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            nevjegy n = new nevjegy();
            this.Hide();
            if (n.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                n.Dispose();
            }
        }

        private void buttonProfil_Click(object sender, EventArgs e)
        {
            Profil profilDialog = new Profil(kerNev,catId);
            this.Hide();
            if (profilDialog.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                profilDialog.Dispose();
            }
        }

        private void Index_Load(object sender, EventArgs e)
        {
            toolTipLogin.SetToolTip(buttonDig, "Digitális Anyag");
            toolTipLogin.SetToolTip(buttonExit, "A program bezárása");
            toolTipLogin.SetToolTip(buttonLogOut, "Kijelentkezés");
            toolTipLogin.SetToolTip(buttonLicense, "Az alkotóról");
            toolTipLogin.SetToolTip(buttonWebOldal, "A hivatalos weboldal");
            toolTipLogin.SetToolTip(buttonProfil, "Felhasználói profil");
            toolTipLogin.SetToolTip(buttonFelhKezelo, "Felhasználók kezelése");
        }

        private void buttonFelhKezelo_Click(object sender, EventArgs e)
        {
            Felhasznalok fh = new Felhasznalok();
            this.Hide();
            if (fh.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                fh.Dispose();
            }
        }

        private void buttonDig_Click(object sender, EventArgs e)
        {
            konyv k = new konyv(catId);
            this.Hide();
            if (k.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                k.Dispose();
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Bejelentkezes b = new Bejelentkezes();
            b.Show();
            this.Dispose();
        }
    }
}
