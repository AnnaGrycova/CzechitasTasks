using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using Newtonsoft.Json;

namespace Lekce_8___Soubory
{
    class Program
    {
        static void Main(string[] args)
        {
            //string nazevSouboru = @"soubor.txt";
            //string cestaKSouboru = @"C:\Czechitas\C# 2 Jaro 2021\Lekce 9 - Soubory\Lekce 9 - Soubory\bin\Debug\";
            //string celaCesta = Path.Combine(cestaKSouboru, nazevSouboru);

            // spolecne pro vsechny uzivatele (C:\ProgramData)
            // string cestaKAplikacnimDatum = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            // pro kazdeho uzivatele cesta k souborum do sveho profilu (C:\Users\AktualniUzivatel\AppData\Roaming)
            string cestaKSoukromymAplikacnimDatum = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cestaKUzivatelskymDatum = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string nazevProgramu = "Kartoteka";
            string databazeKartoteky = "databaze.dbf"; // databaze.jarda.dbf

            string cestaKDatabazi = Path.Combine(cestaKSoukromymAplikacnimDatum, nazevProgramu, databazeKartoteky);
            Console.WriteLine(cestaKDatabazi);

            if (!Directory.Exists(Path.GetDirectoryName(cestaKDatabazi)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(cestaKDatabazi));
            }

            if (File.Exists(cestaKDatabazi))
            {
                string textZdatabaze = File.ReadAllText(cestaKDatabazi);
                Console.WriteLine(textZdatabaze);
            }
            else
            {
                File.WriteAllText(cestaKDatabazi, "Ahoj, toto je první text.");
            }

            // pokrocilejsi prace se soubory

            //StreamWriter writer = new StreamWriter(cestaKDatabazi, append: true);
            //writer.WriteLine("Dalsi radek");
            //writer.WriteLine("Treti radek");
            //writer.WriteLine("Ctvrty radek");
            //writer.Close();

            using (StreamWriter writer = new StreamWriter(cestaKDatabazi, append: true))
            {
                writer.WriteLine("Dalsi radek");
                writer.WriteLine("Treti radek");
                writer.WriteLine("Ctvrty radek");
            }
            
            //StreamReader reader = new StreamReader(cestaKDatabazi);
            //while(!reader.EndOfStream)
            //{
            //    string radek = reader.ReadLine();
            //    Console.WriteLine("Radek: " + radek);
            //}
            //reader.Close();

            using(StreamReader reader = new StreamReader(cestaKDatabazi))
            {
                while (!reader.EndOfStream)
                {
                    string radek = reader.ReadLine();
                    Console.WriteLine("Radek: " + radek);
                }
            }

            // serializace a deserializace dat do souboru

            Navsteva navsteva = new Navsteva("Jarda", 10);
            navsteva.Jmeno = "Jarda";
            navsteva.Vek = 10;

            VzacnaNavsteva vzacnaNavsteva = new VzacnaNavsteva();
            vzacnaNavsteva.Jmeno = "Vitek";
            vzacnaNavsteva.Vek = 11;
            vzacnaNavsteva.Stat = "Ceska Republika";

            List<Navsteva> listNavstev = new List<Navsteva>();
            listNavstev.Add(navsteva);
            listNavstev.Add(vzacnaNavsteva);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Navsteva>), new Type[] { typeof(VzacnaNavsteva) });
            using (StreamWriter writer = new StreamWriter("navsteva.xml"))
            {
                serializer.Serialize(writer, listNavstev);
            }
            
            List<Navsteva> deserializovanaNavsteva;

            using(StreamReader reader = new StreamReader("navsteva.xml"))
            {
                deserializovanaNavsteva = serializer.Deserialize(reader) as List<Navsteva>;
            }

            string listNavstevJson = JsonConvert.SerializeObject(listNavstev, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("navsteva.json", listNavstevJson);

            List<Navsteva> deserializovanyJsonList = JsonConvert.DeserializeObject<List<Navsteva>>(listNavstevJson);

            Console.ReadLine();
        }
    }
}
