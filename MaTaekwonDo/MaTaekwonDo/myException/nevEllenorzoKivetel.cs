using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTaekwonDo.myException
{
    public class nevEllenorzoKivetel:Exception
    {
        public nevEllenorzoKivetel(string message)
            : base(message) { }
    }
}
