using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        konyv k = new konyv();
        private DataTable ajanlo;
        public tartalom()
        {
            InitializeComponent();
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {

            k.Show();
            this.Close();
        }
        #region TabControl
        public void megjelenitTab(int v)
        {
            if (v == 0)
            {
                tabControl1.SelectTab("tabPageAjanlo");
            }
            if (v == 1)
            {
                tabControl1.SelectTab("tabPageBevezeto");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("tabPageTortenet");
            }
            if (v == 3)
            {
                tabControl1.SelectTab("tabPagematortenet");
            }
            if (v == 4)
            {
                tabControl1.SelectTab("tabPagetanai");
            }
            if (v == 5)
            {
                tabControl1.SelectTab("tabPageeletpontok");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            if (v == 2)
            {
                tabControl1.SelectTab("");
            }
            #endregion
        }

        private void buttonSzerkeszt_Click(object sender, EventArgs e)
        {

        }

        private void tartalom_Load(object sender, EventArgs e)
        {
            buttonSzerkeszt.Enabled = false;
            buttonSzerk.Enabled = false;
        }

        private void textBoxAjanlo_TextChanged(object sender, EventArgs e)
        {
            textBoxAjanlo.ReadOnly = true;
            mdi = a.connectToDic();
            mdi.open();
            string query = "SELECT * FROM szoveg WHERE id=1";
            string res = mdi.executeScalarQuery(query);
            textBoxAjanlo.Text = res.ToString();
            

        }
    }
}
