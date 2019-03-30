using MaTaekwonDo.Model;
using MaTaekwonDo.myException;
using MaTaekwonDo.Valdiation;
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
        private DataTable catDT;
        private DataTable nemDT;
        private DataTable klubDT;
        private DataTable ovDT;
        private Adatok a;
        public Szerkeszt(Adatok a)
        {
           
            InitializeComponent();
            
            this.a = a;
            textBoxFnev.Text = a.getfnev();
            textBoxEmail.Text = a.getEmail();
            textBoxKnev.Text = a.getKnev();
            textBoxPwd.Text = a.getPwd();
            textBoxVnev.Text = a.getVnev();
            comboBoxNem.SelectedItem = a.getFiu();

            Adatbazis db = new Adatbazis();
            MySQLDataInterface mdi = db.kapcsolodas();
            mdi.open();

            string query = "SELECT * FROM category";
            catDT=mdi.getToDataTable(query);
            comboBoxJog.DataSource = catDT;
            comboBoxJog.ValueMember = "id";
            comboBoxJog.DisplayMember = "name";
 
            comboBoxJog.SelectedIndex = a.getCategoryId() - 1;

            string queryKlub = "SELECT * FROM klub";
            klubDT = mdi.getToDataTable(queryKlub);
            comboBoxKlub.DataSource = klubDT;
            comboBoxKlub.ValueMember = "ID";
            comboBoxKlub.DisplayMember = "nev";
            comboBoxKlub.SelectedIndex = a.getKlub();

            string queryOv = "SELECT * FROM ovfokozatok";
            ovDT = mdi.getToDataTable(queryOv);
            comboBoxOv.DataSource = ovDT;
            comboBoxOv.ValueMember = "id";
            comboBoxOv.DisplayMember = "nev";

            comboBoxOv.SelectedIndex = a.getOvfok();
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
            NevEllenorzes ne = new NevEllenorzes(textBoxKnev.Text);
            try
            {
                ne.Ellenorzes();
                a.setKnev(textBoxKnev.Text);
            }
            catch(nevEllenorzoKivetel nek)
            {
                errorProvider1.SetError(textBoxKnev, nek.Message);
            }

            
            a.setFnev(textBoxFnev.Text);
            if (isValidRights())
            {
                a.setCategoryId(Convert.ToInt32(comboBoxJog.SelectedValue));
            }
            else
            {
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(comboBoxJog, "A választás kötelező!");
            }
           
            a.setEmail(textBoxEmail.Text);
            
            a.setKlub(Convert.ToInt32(comboBoxKlub.SelectedValue));
            if (isValidGender())
            {
                a.setFiu(comboBoxNem.SelectedItem.ToString());
            }
            else
            {
                
                this.DialogResult = DialogResult.None;
                errorProvider1.SetError(comboBoxNem, "A választás kötelező!");
            }
            
            a.setOvfok(Convert.ToInt32(comboBoxOv.SelectedValue));
            a.setPwd(textBoxPwd.Text);
            a.setVnev(textBoxVnev.Text);
        }
        private bool isValidGender()
        {
            return comboBoxNem.SelectedItem != null;
        }
        private bool isValidRights()
        {
            return comboBoxJog.SelectedItem != null;
        }
    }
}
