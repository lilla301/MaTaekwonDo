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

        public Profil(string kerNev)
        {

            InitializeComponent();
            this.kerNev = kerNev;
            label2.Text = kerNev;
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

            /*esemenyLista = mdi.getToDataTable("SELECT FROM esemenyek");
            dataGridViewEsemenyek.DataSource = esemenyLista;
            dataGridViewEsemenyek.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEsemenyek.Columns["ido"].HeaderText = "Időpont";
            dataGridViewEsemenyek.Columns["leiras"].HeaderText = "Leírás";*/
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonVissza_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
