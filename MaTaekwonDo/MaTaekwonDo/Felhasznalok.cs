using MaTaekwonDo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Adatok d;
        string knevSzuro = "keresztnev";
        string vNevSzuro = "vezeteknev";
        
        public Felhasznalok()
        {
            InitializeComponent();
            textBoxNevSzuro.Visible = false;
            textBoxVNev.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
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
            //Felhasználói szintek beolvasása
            mdi = a.kapcsolodas();
            mdi.open();
            category = mdi.getToDataTable("SELECT * FROM category");
            dataGridViewCategory.DataSource = category;
            dataGridViewCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCategory.Columns[0].Width = 20;
            dataGridViewCategory.Columns[1].Width = 70;
            dataGridViewCategory.ReadOnly = true;

            //Felhassználók beolvasása több táblából
            dataGridViewUser.AllowUserToDeleteRows = false;
            dataGridViewUser.ReadOnly = false;
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

            textBoxNevSzuro.Visible = true;
            textBoxVNev.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count>0 )
            {

                Szerkeszt sz = new Szerkeszt();
                sz.textBoxFnev.Text = this.dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                    /*Adatok modositottAdat = new Adatok(Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["name"].Value),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["szemelyID"].Value),
                        dataGridViewUser.SelectedRows[0].Cells["felhasznalonev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["jelszo"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["vezeteknev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["keresztnev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["email"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["neme"].Value.ToString(),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["nev"].Value),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["nev1"].Value));
                    Szerkeszt sz = new Szerkeszt(modositottAdat);
                    if (sz.ShowDialog() == DialogResult.OK)
                    {
                        modositottAdat = sz.getModositottAdat();
                        Adatbazis a = new Adatbazis();
                        MySQLDataInterface mdi = a.kapcsolodas();
                        mdi.open();
                        string query = "";
                        query += "UPDATE user ";
                        query += "SET categoryID=" + d.getCategoryId() + "," +
                            "felhasznalonev='" + d.getfnev() + "', jelszo='" + d.getPwd() + "', vezeteknev='" + d.getVnev() + "," +
                            "keresztnev='" + d.getKnev() + "', email='" + d.getEmail() + "', neme='" + d.getFiu() + "'," +
                            "klub=" + d.getKlub() + ", ovfokozat=" + d.getOvfok() + ", WHERE szemelyID=" + d.getSzemelyID() + ";";

                        mdi.executeDMQuery(query);
                        dataGridViewUser.SelectedRows[0].Cells["categoryID"].Value = d.getCategoryId();
                        dataGridViewUser.SelectedRows[0].Cells["felhasznalonev"].Value = d.getfnev();
                        dataGridViewUser.SelectedRows[0].Cells["jelszo"].Value = d.getPwd();
                        dataGridViewUser.SelectedRows[0].Cells["vezeteknev"].Value = d.getVnev();
                        dataGridViewUser.SelectedRows[0].Cells["keresztnev"].Value = d.getKnev();
                        dataGridViewUser.SelectedRows[0].Cells["email"].Value = d.getEmail();
                        dataGridViewUser.SelectedRows[0].Cells["neme"].Value = d.getFiu();
                        dataGridViewUser.SelectedRows[0].Cells["klub"].Value = d.getKlub();
                        dataGridViewUser.SelectedRows[0].Cells["ovfokozat"].Value = d.getOvfok();*/

                    }
                
            }
        }

        private void textBoxNevSzuro_KeyDown(object sender, KeyEventArgs e)
        {
            user.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", knevSzuro, textBoxNevSzuro.Text);
        }

        private void textBoxVNev_KeyDown(object sender, KeyEventArgs e)
        {
            user.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", vNevSzuro, textBoxVNev.Text);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Figyelem", "Biztosan törölni szeretné?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                try
                {
                    
                    Adatbazis a = new Adatbazis();
                    MySQLDataInterface mdi = a.kapcsolodas();
                    string query= "DELETE FROM user WHERE szemelyID =" +dataGridViewUser.SelectedRows[0].Cells["szemelyID"].Value +";";
                    mdi.open();
                    mdi.executeDMQuery(query);
                    mdi.close();
                    int sor = dataGridViewUser.SelectedRows[0].Index;
                    dataGridViewUser.Rows.RemoveAt(sor);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
