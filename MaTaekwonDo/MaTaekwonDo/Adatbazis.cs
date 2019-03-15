using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MaTaekwonDo
{
    class Adatbazis
    {
        public MySQLDataInterface kapcsolodas()
        {
            MySQLDataInterface mdi = new MySQLDataInterface();
            mdi.setErrorToUserInterface(true);
            mdi.setErrorToGraphicalUserInterface(false);
            mdi.setKapcsolodasSzerverAdatok("localhost", "usermanagment", "3306");
            mdi.setKapcsolodasFelhasznaloiAdatok("root", "");
            mdi.kapcsolodasAdatBazishoz();

            return mdi;
        }
       
        #region Módosít Adatot
        /*public void modositAdat(Adatok modositAdat)
        {
            foreach (Adatok d in adat)
            {
                if (modositAdat.getSzemelyID() == d.getSzemelyID())
                {
                    d.setAdat(modositAdat);
                }
            }
        }
        public void frissitAdatot(Adatok modositAdat)
        {
            csatlakozAdatbazishoz();
            try
            {
                MySqlCommand cmdUpdate = new MySqlCommand();
                cmdUpdate.Connection = connection;
                cmdUpdate.CommandText =
                "UPDATE user SET categoryID=@categoryID, " + "szemelyID=@szemelyID, " +
                "username=@username, " + "password=@password, " + "vezeteknev=@vezeteknev, " +
                "keresztnev=@keresztnev, " + "email=@email, " + "neme=@neme, " + "klub=@klub, " + "ovfokozat=@ovfokozat " +
                "WHERE szemelyID=@szemelyID";
                cmdUpdate.Prepare();
                cmdUpdate.Parameters.AddWithValue("@categoryID", modositAdat.getCategoryId().ToString());
                cmdUpdate.Parameters.AddWithValue("@szemelyID", modositAdat.getSzemelyID().ToString());
                cmdUpdate.Parameters.AddWithValue("@username", modositAdat.getfnev());
                cmdUpdate.Parameters.AddWithValue("@password", modositAdat.getPwd());
                cmdUpdate.Parameters.AddWithValue("@vezeteknev", modositAdat.getVnev());
                cmdUpdate.Parameters.AddWithValue("@keresztnev", modositAdat.getKnev());
                cmdUpdate.Parameters.AddWithValue("@email", modositAdat.getEmail());
                cmdUpdate.Parameters.AddWithValue("@neme", modositAdat.getFiu());
                cmdUpdate.Parameters.AddWithValue("@klub", modositAdat.getKlub());
                cmdUpdate.Parameters.AddWithValue("@ovfokozat", modositAdat.getOvfok());

                cmdUpdate.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception("Hibás SQL lekérdezés módosításkor.");
            }
        }
        #endregion
        #region Új Adat
        public void ujAdat(Adatok ujAdat)
        {
            csatlakozAdatbazishoz();
            try
            {
                MySqlCommand cmdInsert = new MySqlCommand();
                cmdInsert.Connection = connection;
                cmdInsert.CommandText =
                "INSERT INTO user(categoryID, szemelyID, username, password, vezeteknev, keresztnev, email, neme, klub, ovfokozat )" +
                " VALUES (@categoryID, @szemelyID, @username, @password, @vezeteknev, @keresztnev, @email, @neme, @klub, @ovfokozat)";
                cmdInsert.Prepare();
                cmdInsert.Parameters.AddWithValue("@categoryID", ujAdat.getCategoryId());
                cmdInsert.Parameters.AddWithValue("@szemelyID", ujAdat.getSzemelyID());
                cmdInsert.Parameters.AddWithValue("@username", ujAdat.getfnev());
                cmdInsert.Parameters.AddWithValue("@password", ujAdat.getPwd());
                cmdInsert.Parameters.AddWithValue("@vezeteknev", ujAdat.getVnev());
                cmdInsert.Parameters.AddWithValue("@keresztnev", ujAdat.getKnev());
                cmdInsert.Parameters.AddWithValue("@email", ujAdat.getEmail());
                cmdInsert.Parameters.AddWithValue("@neme", ujAdat.getFiu());
                cmdInsert.Parameters.AddWithValue("@klub", ujAdat.getKlub());
                cmdInsert.Parameters.AddWithValue("@ovfokozat", ujAdat.getOvfok());
                cmdInsert.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatfelvitel.");
            }
        }
        public void hozzaadListahozAdatot(Adatok ujAdat)
        {
            adat.Add(ujAdat);
        }
        public int getNextSzemelyID()
        {
            csatlakozAdatbazishoz();
            try
            {
                MySqlCommand cmdScalar = new MySqlCommand();
                cmdScalar.Connection = connection;
                cmdScalar.CommandText = "SELECT MAX(szemelyID) FROM user";
                string result = cmdScalar.ExecuteScalar().ToString();
                connection.Close();
                return Convert.ToInt32(result) + 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception("SQL utasitas rossz.");
            }
        }
        #endregion
        #region töröl Adatokat
        public int getId()
        {
            csatlakozAdatbazishoz();
            try
            {
                MySqlCommand cmdScalar = new MySqlCommand();
                cmdScalar.Connection = connection;
                cmdScalar.CommandText = "SELECT MAX(szemelyID) FROM user";
                string result = cmdScalar.ExecuteScalar().ToString();
                connection.Close();
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception("SQL utasitas rossz.");
            }
        }

        public void deleteAdat(int torolId)
        {
            csatlakozAdatbazishoz();
            try
            {
                MySqlCommand cmdDelete = new MySqlCommand();
                cmdDelete.Connection = connection;
                cmdDelete.CommandText =
                    "DELETE FROM user WHERE szemelyID=" + torolId;
                cmdDelete.Prepare();
                cmdDelete.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatfelvitel.");
            }
        }
        public int keresIdAlapjan(int keresId)
        {
            int db = 0;
            foreach (Adatok a in adat)
            {
                if (keresId == a.getSzemelyID())
                {
                    return db;
                }
                db++;
            }
            return -1;
        }

        public void torolListabol(int torolId)
        {

            int hanyadik = keresIdAlapjan(torolId);
            if (hanyadik > -1)
            {
                adat.RemoveAt(hanyadik);
            }

        }*/
        #endregion
    }
}
