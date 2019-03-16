using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Model
{
    class szovegek
    {
        private int id;
        private string cim;
        private string szoveg;
        public szovegek(int id, string cim, string szoveg)
        {
            this.id = id;
            this.cim = cim;
            this.szoveg = szoveg;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId(){
            return id;
        }
        public void setCim(string cim)
        {
            this.cim = cim;
        }
        public string getCim()
        {
            return cim;
        }
        public void setSzoveg(string szoveg)
        {
            this.szoveg = szoveg;
        }
        public string getSzoveg()
        {
            return szoveg;
        }
        public override string ToString()
        {
            return id + ", " + cim + ", " + szoveg + ".";
        }
    }
}
