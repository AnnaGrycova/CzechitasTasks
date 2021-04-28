using System;
using System.IO;
using System.Collections.Generic;

namespace Ukol_nahrani_csv_souboru
{
    class Program
    {
//Do proměnné typu string uložte cestu na plochu aktuálního uživatele
//Zkontrolujte, že na ploše existuje složka Czechitas, a pokud ne, vytvořte ji
//Vytvořte nebo použijte třídu Navsteva(z lekce) a vytvořte list s alespoň 2 návštěvami
//Do složky Czechitas uložte soubor navstevy.csv, ve kterém bude na každém řádku uložena informace o jedné návštěvě z listu, oddělená čárkou např:
//Jarda,10,
//Vitek,11,
//Potom z CSV souboru načtěte návštěvy a zobrazte na konzoli
//Pokud soubor csv již existuje, při spuštění programu jej přepište.
//Nepoužívejte pomocné knihovny pro práci s CSV(CsvHelper apod), csv je jednoduchý formát, který načte třeba Excel :)
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderCzechitas = "Czechitas";
            string pathToCsv = Path.Combine(desktopPath, folderCzechitas, "navstevy.csv");

            if (!Directory.Exists(Path.GetDirectoryName(pathToCsv)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathToCsv));
            }

            Navsteva navstevaJarda = new Navsteva("Jarda", 10);
            navstevaJarda.Jmeno = "Jarda";
            navstevaJarda.Vek = 10;

            Navsteva navstevaVitek = new Navsteva();
            navstevaVitek.Jmeno = "Vitek";
            navstevaVitek.Vek = 11;

            List<Navsteva> ListNavstev = new List<Navsteva>()
            {
                navstevaJarda,
                navstevaVitek
            };

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("Jmeno,Vek");
            foreach (var item in ListNavstev)
            {
                sb.AppendLine(item.ToCsv());  // BTW je potřeba implementovat ToString ve tříde Navsteva
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(pathToCsv, sb.ToString());
        }
    }
}
