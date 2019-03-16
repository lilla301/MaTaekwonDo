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
    public partial class Profil : Form
    {
        private MySQLDataInterface mdi;
        private DataTable users;
        private DataTable esemenyLista;
        Adatbazis a = new Adatbazis();
        Bejelentkezes b = new Bejelentkezes();
        private string kerNev;
        private int catId;

        public Profil(string kerNev, int catId)
        {

            InitializeComponent();
            this.kerNev = kerNev;
            this.catId = catId;
            label2.Text = kerNev;
            
            if(catId==1 || catId == 2)
            {
                buttonAdd.Visible = true;
            }
            else
            {
                buttonAdd.Visible = false;
            }
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            mdi = a.kapcsolodas();
            mdi.open();
            users = mdi.getToDataTable("SELECT vezeteknev, keresztnev, nev FROM user, klub WHERE klub.ID = user.klub");
            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Columns[0].Width = 70;
            dataGridViewUsers.Columns[1].Width = 70;
            dataGridViewUsers.Columns[2].Width = 70;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.Columns["nev"].HeaderText = "Klub";
            dataGridViewUsers.Columns["vezeteknev"].HeaderText = "Vezetéknév";
            dataGridViewUsers.Columns["keresztnev"].HeaderText = "Keresztnév";

            esemenyLista = mdi.getToDataTable("SELECT * FROM esemenynaptar WHERE ev=2019");
            dataGridViewEsemenyek.DataSource = esemenyLista;
            dataGridViewEsemenyek.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEsemenyek.Columns["ev"].HeaderText = "Év";
            dataGridViewEsemenyek.Columns["idopont"].HeaderText = "Időpont";
            dataGridViewEsemenyek.Columns["megnevezes"].HeaderText = "Leírás";
            dataGridViewEsemenyek.Columns[1].Width = 200;
            dataGridViewEsemenyek.Columns[2].Width = 600;
            dataGridViewEsemenyek.ReadOnly = true;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            esemenyek events = new esemenyek();
            this.Hide();
            if (events.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                events.Dispose();
            }

        }
    }
}
