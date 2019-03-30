using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Model
{
    public class esemenyNaptar
    {
        private string idopont;
        private int ev;
        private string megnevezes;
        public esemenyNaptar() { }

        internal void setIdopont(string idopont)
        {
            this.idopont = idopont;
        }
        public string getIdopont()
        {
            return idopont;
        }

        internal void setEv(int ev)
        {
            this.ev = ev;
        }
        public int getEv()
        {
            return ev;
        }
        public void setMegnevezes(string megnevezes)
        {
            this.megnevezes = megnevezes;
        }
        public string getMegnevezes()
        {
            return megnevezes;
        }
    }
}
