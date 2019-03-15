using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo
{
    class Kategoria
    {
        string name;
        int Id;
        public Kategoria(int Id, string name)
        {
            this.Id = Id;
            this.name = name;
        }
        public int getId()
        {
            return Id;
        }
        public string getName()
        {
            return name;
        }
        public void setId(int Id)
        {
            this.Id = Id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
    }
}
