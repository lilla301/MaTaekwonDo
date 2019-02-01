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
        private DataGridViewComboBoxColumn klub;
        private DataGridViewComboBoxColumn ovfok;
        private DataGridViewCheckBoxColumn neme;
        private DataGridViewComboBoxColumn szint;
        private DataTable tableKlub;
        private DataTable tableSzint;
        private DataTable tableOv;
        bool modositottE = false;
        Adatbazis a = new Adatbazis();
        Adatok d = new Adatok();
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

            user = mdi.getToDataTable("SELECT * FROM user");
            dataGridViewUser.DataSource = user;
            dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUser.Columns[0].Width = 20;
            dataGridViewUser.Columns[1].Width = 20;
            dataGridViewUser.AllowUserToDeleteRows = false;
            dataGridViewUser.ReadOnly = false;

            //dataGridViewUser.Columns["szemelyID"].Visible = true;
            //dataGridViewUser.Columns["categoryID"].Visible = false;
            //dataGridViewUser.Columns["klub"].Visible = false;
            dataGridViewUser.Columns["categoryID"].HeaderText = "Felhasználói szint";
            dataGridViewUser.Columns["szemelyID"].HeaderText = "ID";
            dataGridViewUser.Columns["felhasznalonev"].HeaderText = "Felhasználónév";
            dataGridViewUser.Columns["jelszo"].HeaderText = "Jelszó";
            dataGridViewUser.Columns["vezeteknev"].HeaderText = "Vezetéknév";
            dataGridViewUser.Columns["keresztnev"].HeaderText = "Keresztnév";
            dataGridViewUser.Columns["email"].HeaderText = "Email";
            dataGridViewUser.Columns["neme"].HeaderText = "Férfi";
            //dataGridViewUser.Columns["ovfokozat"].Visible = false;
            modositottE = false;
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
    }
}
