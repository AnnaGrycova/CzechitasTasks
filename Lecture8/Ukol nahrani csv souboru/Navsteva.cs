using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol_nahrani_csv_souboru
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

        public string ToCsv()
        {
            return $"{Jmeno},{Vek}";
        }
    }
}
