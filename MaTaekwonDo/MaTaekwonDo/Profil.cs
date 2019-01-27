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
    public partial class Profil : Form
    {
        private MySQLDataInterface mdi;
        private DataTable users;
        private DataTable klubDT;
        private DataGridViewComboBoxColumn ComboBoxKlub;
        Adatbazis a = new Adatbazis();

        public Profil()
        {
            InitializeComponent();
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            mdi = a.kapcsolodas();
            mdi.open();
            users = mdi.getToDataTable("SELECT vezeteknev, keresztnev, klub FROM user");
            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Columns[0].Width = 70;
            dataGridViewUsers.Columns[1].Width = 70;
            dataGridViewUsers.Columns[2].Width = 70;
            dataGridViewUsers.Columns["klub"].Visible = false;
            dataGridViewUsers.ReadOnly = true;


            if (ComboBoxKlub == null)
            {
                ComboBoxKlub = new DataGridViewComboBoxColumn();
                ComboBoxKlub.HeaderText = "Klub";
                ComboBoxKlub.Name = "KlubCombo";

                MySQLDataInterface mdiKlub;
                mdiKlub = a.kapcsolodas();
                mdiKlub.open();
                klubDT = new DataTable();
                klubDT = mdiKlub.getToDataTable("SELECT id,nev FROM klub");
                mdiKlub.close();
                ComboBoxKlub.DataSource = klubDT;

                ComboBoxKlub.ValueMember = "id";
                ComboBoxKlub.DisplayMember = "nev";


                dataGridViewUsers.Columns.Add(ComboBoxKlub);
                setKlubComboValue();
            }
        }
        private void setKlubComboValue()
        {
            for (int i = 0; i < dataGridViewUsers.Rows.Count - 1; i++)
            {
                dataGridViewUsers.Rows[i].Cells["KlubCombo"].Value = klubDT.Rows[i]["id"];
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
