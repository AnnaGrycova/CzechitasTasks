using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol_z_hodiny___List_double
{
    public class Writer
    {
        public static void Vypis(List<double> list)
        {
            foreach (double cislo in list) //nevidim, co je zvenku te metody, vidim, co se predava v argumentu, proto je tam list a ne cisla
            {
                Console.WriteLine(cislo);
            }
        }

        public static void VypisPocet(List<double> list)
        {
            Console.WriteLine(String.Format(" -- pocet cisel: {0}", list.Count));
        }
    }
}
