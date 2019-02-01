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
    public partial class Felhasznalok : Form
    {
        private MySQLDataInterface mdi;
        private DataTable category;
        private DataTable user;
        bool modositottE = false;
        Adatbazis a = new Adatbazis();
        Adatok d = new Adatok();
        string knevSzuro = "keresztnev";
        public Felhasznalok()
        {
            InitializeComponent();
        }

        private void Felhasznalok_Load(object sender, EventArgs e)
        {
            mdi = a.kapcsolodas();
            mdi.open();
            category = mdi.getToDataTable("SELECT * FROM category");
            dataGridViewCategory.DataSource = category;
            dataGridViewCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCategory.Columns[0].Width = 20;
            dataGridViewCategory.Columns[1].Width = 70;

            dataGridViewUser.AllowUserToDeleteRows = false;
            dataGridViewUser.ReadOnly = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (modositottE)
            {
                if (MessageBox.Show("Nem mentett módosításai vannak. Biztosan ki szeretne lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonBetolt_Click(object sender, EventArgs e)
        {
            user = mdi.getToDataTable("Select category.name, szemelyID, felhasznalonev, jelszo, vezeteknev, keresztnev, email, neme, klub.nev, ovfokozatok.nev FROM user, ovfokozatok, category, klub WHERE klub.ID = user.klub AND category.id = user.categoryID AND ovfokozatok.id = user.ovfokozat");
            dataGridViewUser.DataSource = user;
            dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUser.Columns[7].Width = 40;

            dataGridViewUser.Columns["name"].HeaderText = "Felhasználói szint";
            dataGridViewUser.Columns["szemelyID"].HeaderText = "Személy azonosító";
            dataGridViewUser.Columns["felhasznalonev"].HeaderText = "Felhasználónév";
            dataGridViewUser.Columns["jelszo"].HeaderText = "Jelszó";
            dataGridViewUser.Columns["vezeteknev"].HeaderText = "Vezetéknév";
            dataGridViewUser.Columns["keresztnev"].HeaderText = "Keresztnév";
            dataGridViewUser.Columns["email"].HeaderText = "Email Cím";
            dataGridViewUser.Columns["neme"].HeaderText = "Nem";
            dataGridViewUser.Columns["nev"].HeaderText = "Klub";
            dataGridViewUser.Columns["nev1"].HeaderText = "Övfokozat";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user.DefaultView.RowFilter = string.Format("Convert([{0}],'System.String') Like '%{1}'", knevSzuro, textBox1.Text);
        }
    }
}
