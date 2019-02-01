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
    public partial class Bejelentkezes : Form
    {
        public Bejelentkezes()
        {
            InitializeComponent();   
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonLog_Click(object sender, EventArgs e)
        { 
            string user = textBoxUname.Text;
            string pwd = textBoxPwd.Text;
            Adatbazis a = new Adatbazis();
            MySQLDataInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "SELECT categoryID FROM user WHERE felhasznalonev= \"" + user + "\" and jelszo =\"" + pwd + "\"";
            string result = mdi.executeScalarQuery(query);
            if (result == "1")
            {
                
                    Index i=new Index(result.ToString());
                    i.Show();
                    this.Hide();

            }
            else if (result == "2" || result=="3")
            {
                Index i = new Index(result.ToString());
                i.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSzasz_Click(object sender, EventArgs e)
        {
            textBoxUname.Text = "SzaszP";
        }

        private void buttonSzalay_Click(object sender, EventArgs e)
        {
            textBoxUname.Text = "SzalayG";
        }

        private void buttonHarmat_Click(object sender, EventArgs e)
        {
            textBoxUname.Text = "HarmatL";
        }

        private void buttonMate_Click(object sender, EventArgs e)
        {
            textBoxUname.Text = "MateZ";
        }

        private void buttonSolti_Click(object sender, EventArgs e)
        {
            textBoxUname.Text = "SoltiA";
        }

        private void textBoxPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                buttonLog.PerformClick();
            }
        }
        
    }
}
