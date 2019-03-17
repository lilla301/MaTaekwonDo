using MaTaekwonDo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Repository
{
    partial class AdatRepo
    {
        private void addDataToDB(Adatok adat)
        {
            Adatbazis md = new Adatbazis();
            MySQLDataInterface mdi = md.kapcsolodas();
            string query = adat.getBeillesztQuery();
            mdi.open();
            mdi.executeDMQuery(query);
            mdi.close();
        }
    }
}
