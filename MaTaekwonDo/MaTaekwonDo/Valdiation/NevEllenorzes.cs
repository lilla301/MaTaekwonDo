using MaTaekwonDo.myException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.Valdiation
{
    class NevEllenorzes
    {
        private string nev;
        public NevEllenorzes(string nev)
        {
            this.nev = nev;
        }
        public bool Ellenorzes()
        {
            bool siker = true;
            if (siker==uresE())
            {
                throw new nevEllenorzoKivetel("A mező nem lehet üres");
            }
            if (siker==elsoNemNagybetu())
            {
                throw new nevEllenorzoKivetel("A mező első betűje nagy kell, hogy legyen");
            }
            if (siker==tobbiNagyBetu())
            {
                throw new nevEllenorzoKivetel("A mező többi betűje nem lehet nagy");
            }
            if (siker==tartalmazSzamot())
            {
                throw new nevEllenorzoKivetel("A mező nem tartalmazhat számot");
            }
            return siker;
        }
        /// <summary>
        /// vizsgálja, hogy a név tartalmaz-e számot
        /// </summary>
        /// <returns>false ha igen, true ha a név helyes</returns>
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
        /// <summary>
        /// végigmegy a neven az első betűt nem vizsgálva, hogy a többi nagybetű-e
        /// </summary>
        /// <returns>false ha nagybetűket tartalmaz, true ha jó a név</returns>
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
        /// <summary>
        /// vizsgálja, hogy az első betű nagybetű-e
        /// </summary>
        /// <returns>true ha nem, false ha igen</returns>
        private bool elsoNemNagybetu()
        {
            
            if (!char.IsUpper(nev.ElementAt(0)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// vizsgálja, hogy egy mező üresen lett-e hagyva vagy sem
        /// </summary>
        /// <returns>true ha üres a mező, false ha nem</returns>
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
