using MaTaekwonDo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Repository
{
    partial class AdatRepo
    {
        List<Adatok> adatok;
        public AdatRepo()
        {
            adatok = new List<Adatok>();
            fillDataListFromDB();
        }
        private void fillDataListFromDB()
        {
            Adatbazis md = new Adatbazis();
            MySQLDataInterface mdi = md.kapcsolodas();
            mdi.open();
            string query = "Select category.name, szemelyID, felhasznalonev, jelszo, vezeteknev, keresztnev, email, neme, klub.nev, ovfokozatok.nev FROM user, ovfokozatok, category, klub WHERE klub.ID = user.klub AND category.id = user.categoryID AND ovfokozatok.id = user.ovfokozat";
            DataTable dtAdat = mdi.getToDataTable(query);
            mdi.close();

            foreach (DataRow row in dtAdat.Rows)
            {
                int szemelyId = Convert.ToInt32(row["szemelyID"].ToString());
                int categoryId = Convert.ToInt32(row["szemelyID"].ToString());
                string fnev = row["felhasznalonev"].ToString();
                string pwd = row["jelszo"].ToString();
                string veznev = row["vezeteknev"].ToString();
                string kernev = row["keresztnev"].ToString();
                string email = row["email"].ToString();
                string neme =row["neme"].ToString();
                int klub = Convert.ToInt32(row["klub"].ToString());
                int ov = Convert.ToInt32(row["ovfokozat"].ToString());

                Adatok d = new Adatok(categoryId, szemelyId, fnev, pwd, veznev, kernev, email, neme, klub, ov);
                adatok.Add(d);
            }
        }
        
        public DataTable getDataToDataTable()
        {
            DataTable ddt = new DataTable();
            ddt.Columns.Add("Kategória azonosító", typeof(int));
            ddt.Columns.Add("Személy azonosító", typeof(int));
            ddt.Columns.Add("Felhasználónév", typeof(string));
            ddt.Columns.Add("Jelszó", typeof(string));
            ddt.Columns.Add("Vezetéknév", typeof(string));
            ddt.Columns.Add("Keresztnév", typeof(string));
            ddt.Columns.Add("Email", typeof(string));
            ddt.Columns.Add("Neme", typeof(int));
            ddt.Columns.Add("Klub", typeof(int));
            ddt.Columns.Add("Övfokozat", typeof(int));
            foreach (Adatok d in adatok)
            {
                ddt.Rows.Add(d.getCategoryId(), d.getSzemelyID(), d.getfnev(), d.getPwd(), d.getVnev(), d.getKnev(), d.getEmail(), d.getFiu(), d.getKlub(), d.getOvfok());
            }
            return ddt;
        }
    }
}
