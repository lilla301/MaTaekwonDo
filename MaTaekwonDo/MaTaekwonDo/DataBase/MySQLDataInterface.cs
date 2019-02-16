using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MaTaekwonDo
{
    class MySQLDataInterface
    {
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommandBuilder commandBuilder;

        private string server;
        private string db;
        private string user;
        private string pwd;
        private string port;
        private string ssl_mode;

        //hiba az utasítában
        private string errorMessage;
        bool errorToUserInterface;
        bool errorToGraphicalUserInterface;

        public MySQLDataInterface()
        {
            server = string.Empty;
            db = string.Empty;
            user = string.Empty;
            pwd = string.Empty;
            port = string.Empty;
            ssl_mode = "none";

            errorMessage = string.Empty;
            errorToUserInterface = false;
            errorToGraphicalUserInterface = false;
        }
        public void setErrorToUserInterface(bool etui)
        {
            this.errorToUserInterface = etui;
        }
        public void setErrorToGraphicalUserInterface(bool eGui)
        {
            this.errorToGraphicalUserInterface = eGui;
        }
        private void writeErrorToTui()
        {
            Console.WriteLine("Hiba az adatbázis művelet közben:");
            Console.WriteLine(errorMessage);
        }
        private void writeErrorToGgrapichalUserInterface()
        {
            MessageBox.Show(
                "Adatábzis hiba: " + errorMessage,
                "Adatbázis hiba...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
           );
        }
        private void setErrorData(string message)
        {
            errorMessage = message;
            if (errorToUserInterface)
            {
                if (errorToGraphicalUserInterface)
                    writeErrorToGgrapichalUserInterface();
                else
                    writeErrorToTui();
            }
        }
        private bool hianyosParameter()
        {
            bool answer = false;
            if (server == string.Empty)
                answer = true;
            else if (db == string.Empty)
                answer = true;
            else if (user == string.Empty)
                answer = true;
            if (answer == true)

                setErrorData("Valamelyik paraméter hiányzik a kapcsolat létrehozásához");

            return answer;
        }
        private bool marLetezoKapcsolat()
        {
            if (connection == null)
            {
                setErrorData("A kapcsolat nem létezik.");
                return false;
            }
            else
                return true;
        }
        public void setKapcsolodasSzerverAdatok(string server, string db, string port, string ssl_mode = "none")
        {
            this.server = server;
            this.db = db;
            this.port = port;
            this.ssl_mode = ssl_mode;
        }
        public void setKapcsolodasFelhasznaloiAdatok(string user, string pwd)
        {
            this.user = user;
            this.pwd = pwd;
        }
        public bool kapcsolodasAdatBazishoz()
        {
            if (hianyosParameter())
            {
                connection = null;
                return false;
            }
            string connectionString = "SERVER=" + server + ";"
                                   + "DATABASE=" + db + ";"
                                   + "UID=" + user + ";"
                                   + "PASSWORD=" + pwd + ";"
                                   + "PORT=" + port + ";"
                                   + "SSLMode=" + ssl_mode + ";";
            try
            {
                connection = new MySqlConnection(connectionString);
                return true;
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis kapcsolat nem jött létre");
            }
            return true;
        }
        public bool open()
        {
            if (!marLetezoKapcsolat())
            {
                return false;
            }
            else
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                    return true;
                else
                {
                    try
                    {
                        connection.Open();
                        return true;
                    }
                    catch (MySqlException me)
                    {
                        switch (me.Number)
                        {
                            //hibakódók
                            case 0:
                                setErrorData("Adatbáziskapcsolat nem jött létre." + me.Message);
                                break;
                            case 1045:
                                setErrorData("A megadott jelszó vagy felhasználónév nem megfelelő");
                                break;
                            case 1042:
                                setErrorData("A megadott host elérhetetlen");
                                break;
                            default:
                                setErrorData("Az adatbázissal való kapcsolat nem jött létre");
                                break;
                        }
                    }
                    connection = null;
                    return false;
                }
            }
        }
        public bool close()
        {
            if (!marLetezoKapcsolat())
                return false;
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis bezárás hiba");
                return false;
            }
        }
        public bool executableQueryE(string query)
        {
            if (query == string.Empty)
            {
                return false;
            }
            if (!marLetezoKapcsolat())
            {
                return false;
            }
            return true;
        }
        public string egyMezoKijeloles(string query)
        {
            query += "LIMIT 1";
            string result = string.Empty;
            if (!marLetezoKapcsolat())
            {
                return string.Empty;
            }
            if (connection.State != ConnectionState.Open)
            {
                setErrorData("Adatbáziskapcsolat nincs megnyitva");
                return result;
            }
            if (!executableQueryE(query))
            {
                return string.Empty;
            }
            MySqlDataReader dr = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                dr = cmd.ExecuteReader();
                dr.Read();
                result = dr[0].ToString();
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis lekérdezés hiba");
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return result;
        }
        public List<string> getEgyMezoListahoz(string query)
        {
            List<string> lista = new List<string>();
            if (!marLetezoKapcsolat())
            {
                return lista;
            }
            if (connection.State != ConnectionState.Open)
            {
                setErrorData("Adatbázis kapcsolat nincs megnyitva");
                return lista;
            }
            if (!executableQueryE(query))
            {
                return lista;
            }
            MySqlDataReader dr = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr[0] + "");
                }
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis lekérdezés hiba");
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return lista;
        }
        public DataTable getToDataTable(string query)
        {
            DataTable dt = new DataTable();
            if (!marLetezoKapcsolat())
            {
                return dt;
            }
            if (connection.State != ConnectionState.Open)
            {
                setErrorData("Nincs adatbázis kapcsolat");
                return dt;
            }
            if (!executableQueryE(query))
            {
                return dt;
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (cmd == null)
                {
                    return dt;
                }
                dataAdapter = new MySqlDataAdapter(cmd);
                commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dt);
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis lekérdezés hiba");
            }

            return dt;
        }
        public void executeDMQuery(string query)
        {
            if (!marLetezoKapcsolat())
            {
                return;
            }
            if (connection.State != ConnectionState.Open)
            {
                setErrorData("Nincs adatbázis kapcsolat");
                return;
            }
            if (!executableQueryE(query))
            {
                return;
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis lekérdezés hiba");
            }
        }
        public string executeScalarQuery(string query)
        {
            string scalar = string.Empty;
            if (!marLetezoKapcsolat())
            {
                return string.Empty;
            }
            if (connection.State != ConnectionState.Open)
            {
                return scalar;
            }
            if (!executableQueryE(query))
            {
                return scalar;
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                scalar = cmd.ExecuteScalar().ToString();
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis lekérdezés hiba");
            }
            return scalar;
        }
        public void frissitAdatokat(DataTable dt)
        {
            try
            {
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.Update(dt);
            }
            catch (MySqlException e)
            {
                setErrorData("Adatbázis frissítési hiba");
            }
        }
    }
}
