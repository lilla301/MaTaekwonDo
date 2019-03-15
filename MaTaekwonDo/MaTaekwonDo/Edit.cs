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
    public partial class Edit : Form
    {
        private Adatok d;
        private DataTable tableKlub;
        private DataTable tableSzint;
        private DataTable tableOv;

        public Edit(Adatok d)
        {
            this.d = d;
            InitializeComponent();
            feltoltSzuroket();
            textBoxEmail.Text = d.getEmail();
            textBoxKnev.Text = d.getKnev();
            textBoxPwd.Text = d.getPwd();
            textBoxUname.Text = d.getfnev();
            textBoxVnev.Text = d.getVnev();
            comboBoxFelhszint.Text = d.getCategoryId().ToString();
            comboBoxKlub.Text = d.getKlub().ToString();
            comboBoxOvfok.Text = d.getOvfok().ToString();
            if (d.getFiu())
            {
                radioButtonNo.Checked = true;
            }
            else
                radioButtonFerfi.Checked = true;
        }
        public Adatok getModositottAdat()
        {
            return d;
        }
        private void feltoltSzuroket()
        {
            Adatbazis gy = new Adatbazis();
            MySQLDataInterface mdiKlub;
            mdiKlub = gy.kapcsolodas();
            mdiKlub.open();
            tableKlub = new DataTable();
            tableKlub = mdiKlub.getToDataTable("SELECT id,nev FROM klub");
            mdiKlub.close();
            comboBoxKlub.DataSource = tableKlub;
 
            MySQLDataInterface mdiSzint;
            mdiSzint = gy.kapcsolodas();
            mdiSzint.open();
            tableSzint = new DataTable();
            tableSzint = mdiSzint.getToDataTable("SELECT id, name FROM category");
            comboBoxFelhszint.DataSource = tableSzint;

            MySQLDataInterface mdiOv;
            mdiOv = gy.kapcsolodas();
            mdiOv.open();
            tableOv = new DataTable();
            tableOv = mdiOv.getToDataTable("SELECT id, fokozat, nev FROM ovfokozatok");
            mdiOv.close();
            comboBoxOvfok.DataSource = tableOv;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            d.setFnev(textBoxUname.Text);
            d.setPwd(textBoxPwd.Text);
            d.setCategoryId(Convert.ToInt32(comboBoxFelhszint.Text));
            d.setKlub(Convert.ToInt32(comboBoxKlub.Text));
            d.setOvfok(Convert.ToInt32(comboBoxOvfok.Text));
            d.setEmail(textBoxEmail.Text);
            d.setVnev(textBoxVnev.Text);
            d.setKnev(textBoxKnev.Text);
            if (radioButtonNo.Checked)
            {
                d.setFiu(true);
            }
            else
                d.setFiu(false);
            this.Close();

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            feltoltSzuroket();
        }
    }
}
