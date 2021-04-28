using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekce_8___Soubory
{
    public class Navsteva
    {
        public string Jmeno { get; set; }
        public int Vek { get; set; }

        public Navsteva(string jmeno, int vek)
        {
            Jmeno = jmeno;
            Vek = vek;
        }

        public Navsteva()
        {

        }
    }

    public class VzacnaNavsteva : Navsteva
    {
        public string Stat { get; set; }
    }

}
