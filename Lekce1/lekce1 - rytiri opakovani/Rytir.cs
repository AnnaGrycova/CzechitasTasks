using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce1___rytiri_opakovani
{
    class Rytir
    {
        public int PocetBodu;
        public string Jmeno;
        public int StartovaciCislo;

        //public void ZobrazPocetBodu()
        //{
        //    Console.WriteLine("Mám " + PocetBodu + " bodů."); 
        //}

        public override string ToString()
        {
            return $"Rytíř č.{StartovaciCislo} - {Jmeno} získal {PocetBodu} {NaformatujBody()}";
        }

        private string NaformatujBody()
        {

            if (PocetBodu == 1)
            {
                return "bod";
            }
            else if (PocetBodu > 0 && PocetBodu < 5)
            {
                return "body";
            }
            else
            {
                return "bodů";
            }
        }
    }
}
