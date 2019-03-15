using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace MaTaekwonDo
{
    public partial class tartalom : Form
    {
        private MySQLDataInterface mdi;
        Adatbazis a = new Adatbazis();
        private int catId;
        private DataTable ajanlo;
        private string szoveg;
        public tartalom(int catId)
        {
            InitializeComponent();
            setAjanloText();
            this.catId = catId;
            buttonEdit.Enabled = false;
            textBoxAjanlo.ReadOnly = true;

            if (catId == 1 || catId==2)
            {
                buttonEdit.Enabled = true;
            }
            else
            {
                buttonEdit.Enabled = false;
            }
        }
        #region TabControl
        public void megjelenitTab(int v)
        {
            if (v == 1)
            {
                tabControl1.SelectTab("tabPageAjanlo");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("tabPageBevezeto");
            }
            if (v == 3)
            {
                tabControl1.SelectTab("tabPageTortenet");
            }
            if (v == 4)
            {
                tabControl1.SelectTab("tabPagematortenet");
            }
            if (v == 5)
            {
                tabControl1.SelectTab("tabPagetanai");
            }
            if (v == 6)
            {
                tabControl1.SelectTab("tabPageeletpontok");
            }
            if (v == 7)
            {
                tabControl1.SelectTab("");
            }
            if (v == 8)
            {
                tabControl1.SelectTab("");
            }
            if (v == 9)
            {
                tabControl1.SelectTab("");
            }
            if (v == 10)
            {
                tabControl1.SelectTab("");
            }
            if (v ==11)
            {
                tabControl1.SelectTab("");
            }
            if (v == 12)
            {
                tabControl1.SelectTab("");
            }
            if (v == 13)
            {
                tabControl1.SelectTab("");
            }
            if (v == 14)
            {
                tabControl1.SelectTab("");
            }
            if (v == 15)
            {
                tabControl1.SelectTab("");
            }
            if (v == 16)
            {
                tabControl1.SelectTab("");
            }
            if (v == 17)
            {
                tabControl1.SelectTab("");
            }
            if (v == 18)
            {
                tabControl1.SelectTab("");
            }
            #endregion
        }

        private void setAjanloText() {
            Adatbazis a = new Adatbazis();
            MySQLDataInterface mdi = a.connectToDic();
            mdi.open();
            string query = "select * from szoveg where id=" + 1;
            DataTable dt = new DataTable();
            dt = mdi.getToDataTable(query);
            foreach (DataRow row in dt.Rows)
            {
                szoveg = row["szoveg"].ToString();
            }
            textBoxAjanlo.Text = szoveg;
        }

        private void textBoxAjanlo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonVissza_Click_1(object sender, EventArgs e)
        {
            /*konyv k = new konyv();
            k.Show();
            this.Hide();*/
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxAjanlo.ReadOnly = false;
        }
    }
}
