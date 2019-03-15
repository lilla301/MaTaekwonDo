using MySql.Data.MySqlClient;
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
        private int catId;
        private string kerNev;
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

            int i;

            Adatbazis a = new Adatbazis();
            MySQLDataInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "select * from user where felhasznalonev='" + user + "' AND jelszo='"+pwd+"'";
            DataTable dt = new DataTable();
            dt = mdi.getToDataTable(query);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Nem található felhasználó ilyen felhasználónévvel.");
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    catId = Convert.ToInt32(row["categoryID"]);
                    kerNev = row["keresztnev"].ToString();
                }
                Index index = new Index(catId,kerNev);
                index.Show();
                this.Hide();
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
