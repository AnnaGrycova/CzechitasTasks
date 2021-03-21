using System;
using System.Collections.Generic;
using System.Linq;

namespace Ukol_z_hodiny___List_double
{
    class Program
    {
        public static void Main(string[] args)
        {
            var cisla = new List<double>
        {
            0.046939913,
            0.295866297,
            0.852489925,
            0.84994766,
            0.96925183,
            0.946275497,
            0.688903175,
            0.553463564,
            0.59628254,
            0.645816929
        };

            // Vypis vsechna cisla na konzoli (nachystej si pro to funkci)
            Writer.Vypis(cisla);
            Console.WriteLine("\n");
            // Vypis na konzoli pocet cisel v seznamu
            Writer.VypisPocet(cisla);
            // Pridej cislo 0.5 do seznamu
            cisla.Add(0.5);
            Console.WriteLine();
            // vypis prvni cislo ze seznamu, ktere je vetsi nez 0.8
            Console.WriteLine($"Prvni cislo v seznamu vetsi nez 0.8: {cisla.Find(cislo => cislo > 0.8)} \n");
            // najdi nejvetsi cislo v seznamu, vypis, ktere to je, a odstran ho ze seznamu
            //metoda Max ocekava funkci jako argument, nestaci napsat jen Max(cislo);
            //Max(cislo => cislo); - identicka funkce, funkce, ktera nic nedela s argumentem, vrati to same, co se ji preda
            //muze to byt i cisla.Max();
            var nejvetsiCislo = cisla.Max();
            Console.WriteLine($"Odstranuji nejvetsi cislo v seznamu: {nejvetsiCislo} \n\n");
            cisla.Remove(nejvetsiCislo);
            // vypis opet vsechna cisla a jejich 
            Writer.Vypis(cisla);
            Console.WriteLine("\n");
            Writer.VypisPocet(cisla);
        }
    }
}
