using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Model
{
    partial class Adatok
    {
        public string getBeillesztQuery()
        {
            string query = "INSERT INTO user (categoryID, szemelyID, felhasznalonev, jelszo, vezeteknev, keresztnev, email, neme, klub, ovfokozat) VALUES(" +
                this.getCategoryId() +
                ", \"" +
                this.getSzemelyID() +
                "\", \"" +
                this.getfnev() +
                "\", \"" +
                this.getPwd() +
                "\", \"" +
                this.getVnev() +
                "\", \"" +
                this.getKnev() +
                "\", \"" +
                this.getEmail() +
                "\", \"" +
                this.getFiu() +
                "\", \"" +
                this.getKlub() +
                "\", \"" +
                this.getOvfok() +
                "\")";
            return query;
        }

        public string getUpdateQuery()
        {
            string query = "UPDATE user SET categoryID='" +
                this.getCategoryId() +
                "', szemelyID = '" +
                this.getSzemelyID() +
                "', felhasznalonev = '" +
                this.getfnev() +
                "', jelszo = '" +
                this.getPwd() +
                "', vezeteknev = '" +
                this.getVnev() +
                "', keresztnev = '" +
                this.getKnev() +
                "', email = '" +
                this.getEmail() +
                "', neme = '" +
                this.getFiu() +
                "', klub = '" +
                this.getKlub() +
                "', ovfokozat = '" +
                this.getOvfok() +
                "' WHERE szemelyID ='" +
                this.getSzemelyID() +
                "';";
            return query;
        }
        public string getDelQuery()
        {
            string query = "DELETE FROM user WHERE szemelyID ='" +
               this.getSzemelyID() +
               "';";
            return query;
        }
    }
}
