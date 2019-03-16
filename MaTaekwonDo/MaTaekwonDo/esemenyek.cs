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
    public partial class esemenyek : Form
    {
        private MySQLDataInterface mdi;
        private DataTable users;
        private DataTable osszesEsemeny;
        Adatbazis a = new Adatbazis();
        public esemenyek()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void esemenyek_Load(object sender, EventArgs e)
        {
            mdi = a.kapcsolodas();
            mdi.open();
            osszesEsemeny = mdi.getToDataTable("SELECT * FROM esemenynaptar");
            dataGridViewLista.DataSource = osszesEsemeny;
            dataGridViewLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLista.Columns["ev"].HeaderText = "Év";
            dataGridViewLista.Columns["idopont"].HeaderText = "Időpont";
            dataGridViewLista.Columns["megnevezes"].HeaderText = "Leírás";
            dataGridViewLista.Columns[1].Width = 300;
            dataGridViewLista.Columns[2].Width = 800;
            dataGridViewLista.ReadOnly = true;
        }
    }
}
