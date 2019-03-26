using MaTaekwonDo.myException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Validation
{
    public class NevEllenorzes
    {
        private string nev;
        public NevEllenorzes(string nev)
        {
            this.nev = nev;
        }
        public void Ellenorzes()
        {
            if (uresE())
            {
                throw new nevEllenorzoKivetel("A mező nem lehet üres");
            }
            if (elsoNemNagybetu())
            {
                throw new nevEllenorzoKivetel("A mező első betűje nagy kell, hogy legyen");
            }
            if (tobbiNagyBetu())
            {
                throw new nevEllenorzoKivetel("A mező többi betűje nem lehet nagy");
            }
            if (tartalmazSzamot())
            {
                throw new nevEllenorzoKivetel("A mező nem tartalmazhat számot");
            }
        }

        private bool tartalmazSzamot()
        {
            for(int i = 0; i < nev.Length; i++)
            {
                if (char.IsDigit(nev.ElementAt(i)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool tobbiNagyBetu()
        {
            for (int i = 1; i < nev.Length; i++)
            {
                if (char.IsUpper(nev.ElementAt(i)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool elsoNemNagybetu()
        {
            
            if (!char.IsUpper(nev.ElementAt(0)))
            {
                return true;
            }
            return false;
        }

        private bool uresE()
        {
            if (string.IsNullOrEmpty(nev))
            {
                return true;
            }
            return false;
        }
    }
}
