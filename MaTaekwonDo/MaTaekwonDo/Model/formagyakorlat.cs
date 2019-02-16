using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Model
{
    class formagyakorlat
    {
        int formagyakorlatId;
        int szoKod;
        string sorrend;
        public formagyakorlat(int formagyakorlatId, int szoKod, string sorrend)
        {
            this.formagyakorlatId = formagyakorlatId;
            this.szoKod = szoKod;
            this.sorrend = sorrend;
        }
        public int getFormagyakorlatId()
        {
            return formagyakorlatId;
        }
        public int getSzoKod()
        {
            return szoKod;
        }
        public string getSorrend()
        {
            return sorrend;
        }
        public void setFormagyakorlatId(int formagyakorlatId)
        {
            this.formagyakorlatId = formagyakorlatId;
        }
        public void setSzoKod(int szoKod)
        {
            this.szoKod = szoKod;
        }
        public void setSorrend(string sorrend)
        {
            this.sorrend = sorrend;
        }
        public override string ToString()
        {
            return formagyakorlatId + szoKod + sorrend;
        }
    }
}
