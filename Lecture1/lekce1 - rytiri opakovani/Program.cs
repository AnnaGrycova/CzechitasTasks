using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekce1___rytiri_opakovani
{// 1. Rozšiřte třídu rytíř a přidejte vlastnost Jmeno a StartovaciCislo.
 // 2. Nastavte každému novému rytíři jedinečné startovací číslo. Např. prvnímu 1, dalšímu 2, atd.
 // 3. Rozšiřte hlavní program, aby bylo možné pro rytíře zadat jméno i počet bodů.
 // 3a. Podobně, jako je funkce pro zadání čísla z konzole, vytvořte funkci, která načte libovolný text, text nesmí být prázdný nebo jen z mezer. Použijte funkci string.IsNullOrWhiteSpace(text), která umí toto zkontrolovat. Funkci pak použijte pro zadání jména.
 // 4. Vytvořte ve třídě Rytir metodu, která zobrazí informace o rytíři na konzoli: Rytíř č.1 - Bořivoj získal 12 bodů
 // 5. Rozšiřte výsledkovou listinu, aby se zobrazily informace o každém rytíři, využijte funkci pro zobrazení informací o rytíři. 
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program pro zobrazeni vysledku");

            int pocetRytiru = NactiCeleCisloZKonzole("Zadej pocet rytiru: ");
            Console.WriteLine("Zadali jste " + pocetRytiru + " rytířů.");

            Rytir[] rytiri = new Rytir[pocetRytiru]; //pouze deklarace, priprava pameti, ze tam budou ti rytiri, ale zatim tam nic neni

            for (int cisloRytire = 0; cisloRytire < pocetRytiru; cisloRytire++)
            {
                Rytir rytir = new Rytir();
                rytir.StartovaciCislo = cisloRytire + 1;
                rytir.Jmeno = NactiJmenoZKonzole();
                rytir.PocetBodu = NactiCeleCisloZKonzole("Zadej body pro rytíře č. " + (cisloRytire + 1) + ": ");
                rytiri[cisloRytire] = rytir;
            }

            Console.WriteLine("Vysledkova listina");
            for (int cisloRytire = 0; cisloRytire < rytiri.Length; cisloRytire++)
            {
                Rytir rytir = rytiri[cisloRytire];
                if (rytir != null)
                {
                    Console.WriteLine(rytir);
                }
            }

            Console.ReadLine();
        }

        static int NactiCeleCisloZKonzole(string dotaz)
        {
            int cislo = 0;
            bool vysledekPrevodu = false;

            while (!vysledekPrevodu)
            {
                Console.WriteLine(dotaz);
                string pocetText = Console.ReadLine();
                vysledekPrevodu = int.TryParse(pocetText, out cislo);

                if (!vysledekPrevodu)
                {
                    Console.WriteLine("Tohle není číslo");
                }
            }

            return cislo;
        }

        static string NactiJmenoZKonzole()
        {
            string jmeno = "";
            bool textJePrazdny = true;

            while (textJePrazdny)
            {
                Console.WriteLine("Zadej jmeno rytire.");
                jmeno = Console.ReadLine();
                textJePrazdny = string.IsNullOrWhiteSpace(jmeno);
                if (textJePrazdny)
                {
                    Console.WriteLine("Zadaný text je prázdný.");
                }
            }
            return jmeno;
        }
    }
}
