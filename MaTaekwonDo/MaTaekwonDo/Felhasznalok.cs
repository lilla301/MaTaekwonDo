using MaTaekwonDo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        string vNevSzuro = "vezeteknev";
        
        public Felhasznalok()
        {
            InitializeComponent();
            textBoxNevSzuro.Visible = false;
            textBoxVNev.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonNew.Visible = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Biztosan ki szeretne lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void buttonBetolt_Click(object sender, EventArgs e)
        {
            buttonDel.Visible = true;
            buttonEdit.Visible = true;
            buttonNew.Visible = true;
            textBoxNevSzuro.Visible = true;
            textBoxVNev.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
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
            user = mdi.getToDataTable("Select category.name, category.id, szemelyID, felhasznalonev, jelszo, vezeteknev, keresztnev, email, neme, klub.nev, klub, ovfokozatok.nev,ovfokozat FROM user, ovfokozatok, category, klub WHERE klub.ID = user.klub AND category.id = user.categoryID AND ovfokozatok.id = user.ovfokozat");
            //user = mdi.getToDataTable("Select * FROM user");
            dataGridViewUser.DataSource = null;
            dataGridViewUser.DataSource = user;
            dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUser.Columns[7].Width = 40;

            //Fejléc nevek
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

            //fontos adatok, de nem kell az oszlop láthatósága
            dataGridViewUser.Columns["id"].Visible = false;
            dataGridViewUser.Columns["klub"].Visible = false;
            dataGridViewUser.Columns["ovfokozat"].Visible = false;

            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUser.SelectedRows.Count>0 )
            {
                    d = new Adatok(Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["id"].Value),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["szemelyID"].Value),
                        dataGridViewUser.SelectedRows[0].Cells["felhasznalonev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["jelszo"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["vezeteknev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["keresztnev"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["email"].Value.ToString(),
                        dataGridViewUser.SelectedRows[0].Cells["neme"].Value.ToString(),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["klub"].Value),
                        Convert.ToInt32(dataGridViewUser.SelectedRows[0].Cells["ovfokozat"].Value));
                    Szerkeszt sz = new Szerkeszt(d);
                    if (sz.ShowDialog() == DialogResult.OK)
                    {
                        d = sz.getModositottAdat();
                        Adatbazis a = new Adatbazis();
                        MySQLDataInterface mdi = a.kapcsolodas();
                        mdi.open();
                        string query = "";
                        query += "UPDATE user ";
                        query += "SET categoryID=" + d.getCategoryId() + "," +
                            "felhasznalonev='" + d.getfnev() + "', jelszo='" + d.getPwd() + "', vezeteknev='" + d.getVnev() + "'," +
                            "keresztnev='" + d.getKnev() + "', email='" + d.getEmail() + "', neme='" + d.getFiu() + "'," +
                            "klub=" + d.getKlub() + ", ovfokozat=" + d.getOvfok() + " WHERE szemelyID=" + d.getSzemelyID() + ";";

                        Console.WriteLine(query);
                        mdi.executeDMQuery(query);
                        buttonBetolt.PerformClick();

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
                    int sor = dataGridViewUser.SelectedRows[0].Index;
                    dataGridViewUser.Rows.RemoveAt(sor);
                    modositottE = true;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            d = new Adatok();
            Szerkeszt sz = new Szerkeszt(d);
            if (sz.ShowDialog() == DialogResult.OK)
            {
                d = sz.getModositottAdat();
                Adatbazis a = new Adatbazis();
                MySQLDataInterface mdi = a.kapcsolodas();
                mdi.open();
                string query = "";
                query += "INSERT INTO user ";
                query += "(categoryID, szemelyID,felhasznalonev, jelszo, vezeteknev, keresztnev, email, neme, klub, ovfokozat) VALUES" +
                    " ("+d.getCategoryId()+","+d.getSzemelyID()+",'"+d.getfnev()+"','"+d.getPwd()+"','"+d.getVnev()+"','"+d.getKnev()+"','"+d.getEmail()+"','"+d.getFiu()+"',"+d.getKlub()+","+d.getOvfok()+")";

                Console.WriteLine(query);
                mdi.executeDMQuery(query);
                buttonBetolt.PerformClick();

            }
        }
    }
}
