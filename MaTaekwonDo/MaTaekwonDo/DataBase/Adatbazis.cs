using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaTaekwonDo
{
    partial class Adatbazis
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
         public MySQLDataInterface connectToDic()
         {
             MySQLDataInterface mdi = new MySQLDataInterface();
             mdi.setErrorToUserInterface(true);
             mdi.setErrorToGraphicalUserInterface(false);
             mdi.setKapcsolodasSzerverAdatok("localhost", "nagykonyv", "3306");
             mdi.setKapcsolodasFelhasznaloiAdatok("root", "");
             mdi.kapcsolodasAdatBazishoz();

             return mdi;
         }
    }
}
