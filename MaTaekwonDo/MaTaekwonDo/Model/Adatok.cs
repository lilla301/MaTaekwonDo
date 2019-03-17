using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Model
{
    public partial class Adatok
    {
        List<Adatok> adat;
        int categoryID;
        int szemelyID;
        string fnev;
        string Knev;
        string Vnev;
        string pwd;
        string email;
        string fiu;
        int klub;
        int ovfok;

        public Adatok(int categoryID, int szemelyID, string fnev, string pwd, string Vnev, string Knev, string email, string fiu, int klub, int ovfok)
        {
            this.categoryID = categoryID;
            this.szemelyID = szemelyID;
            this.email = email;
            this.fiu = fiu;
            this.fnev = fnev;
            this.klub = klub;
            this.Knev = Knev;
            this.ovfok = ovfok;
            this.pwd = pwd;
            this.Vnev = Vnev;
        }
        public Adatok()
        {

        }
        public Adatok(int szemelyID)
        {
            this.categoryID = 0;
            this.szemelyID = szemelyID;
            this.fnev = string.Empty;
            this.pwd = string.Empty;
            this.Vnev = string.Empty;
            this.Knev = string.Empty;
            this.email = string.Empty;
            this.fiu = string.Empty;
            this.klub = 0;
            this.ovfok = 0;
        }
        #region gettek
        public int getCategoryId()
        {
            return categoryID;
        }
        public int getSzemelyID()
        {
            return szemelyID;
        }
        public string getfnev()
        {
            return fnev;
        }
        public string getKnev()
        {
            return Knev;
        }
        public string getVnev()
        {
            return Vnev;
        }
        public string getPwd()
        {
            return pwd;
        }
        public string getEmail()
        {
            return email;
        }
        public string getFiu()
        {
            return fiu;
        }
        public int getKlub()
        {
            return klub;
        }
        public int getOvfok()
        {
            return ovfok;
        }
        #endregion
        #region settek
        public void setCategoryId(int categoryId)
        {
            this.categoryID = categoryId;
        }
        public void setSzemelyID(int szemelyID)
        {
            this.szemelyID = szemelyID;
        }
        public void setFnev(string fnev)
        {
            this.fnev = fnev;
        }
        public void setKnev(string Knev)
        {
            this.Knev = Knev;
        }
        public void setVnev(string Vnev)
        {
            this.Vnev = Vnev;
        }
        public void setPwd(string pwd)
        {
            this.pwd = pwd;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setFiu(string ferfi)
        {
            this.fiu = ferfi;
        }
        public void setKlub(int klub)
        {
            this.klub = klub; ;
        }
        public void setOvfok(int ovfok)
        {
            this.ovfok = ovfok;
        }

        internal void setAdat(Adatok modositAdat)
        {
            this.categoryID = modositAdat.categoryID;
            this.szemelyID = modositAdat.szemelyID;
            this.fnev = modositAdat.fnev;
            this.Vnev = modositAdat.Vnev;
            this.Knev = modositAdat.Knev;
            this.pwd = modositAdat.pwd;
            this.email = modositAdat.email;
            this.fiu = modositAdat.fiu;
            this.klub = modositAdat.klub;
            this.ovfok = modositAdat.ovfok;
        }
        #endregion
        public override string ToString()
        {
            return "Felhasználói szint: " + categoryID + ", személy azonosítója: " + szemelyID + ", felhasználónév: " + fnev + ", jelszó: " + pwd +
                ",vezetéknév: " + Vnev + ", keresztnév: " + Knev + ", email cím: " + email + ", neme: " + fiu + ", klub: " + klub + ", övfokozat: " + ovfok;
        }
       /* public void setAdat(Adatok modositAdat)
        {
            this.categoryID = modositAdat.categoryID;
            this.szemelyID = modositAdat.szemelyID;
            this.fnev = modositAdat.fnev;
            this.Vnev = modositAdat.Vnev;
            this.Knev = modositAdat.Knev;
            this.pwd = modositAdat.pwd;
            this.email = modositAdat.email;
            this.fiu = modositAdat.fiu;
            this.klub = modositAdat.klub;
            this.ovfok = modositAdat.ovfok;
        }*/

    }
}
