using System;
using System.Collections.Generic;
using System.Text;

namespace Domaci_ukol___list
{
    class Prihlasovani
    {
        List<Student> seznamStudentu;
        Dictionary<string, Predmet> katalogPredmetu;

        public Prihlasovani()
        {
            // 1. nejprve vytvor novy prazdny seznam studentu a uloz ho do promenne seznamStudentu
            seznamStudentu = new List<Student>();            

            // naplnime studenty
            seznamStudentu.Add(new Student("Jan", "Novak"));
            seznamStudentu.Add(new Student("Petra", "Svobodova"));

            // 2. pridej nekolik dalsich studentu
            seznamStudentu.Add(new Student("Jakub", "Schubert"));
            seznamStudentu.Add(new Student("Alena", "Hajkova"));

            //seznamStudentu = new List<Student>
            //{
            //    // naplnime studenty
            //    new Student("Jan", "Novak"),
            //    new Student("Petra", "Svobodova"),

            //    // 2. pridej nekolik dalsich studentu
            //    new Student("Jakub", "Kratochvil"),
            //    new Student("Alena", "Hajkova")
            //};

            // 3. vypis seznam studentu na konzoli
            foreach (Student student in seznamStudentu)
            {
                Console.WriteLine(student);
            }

            // vytvorime katalog predmetu, vytvorime nejake predmety
            katalogPredmetu = new Dictionary<string, Predmet>
        {
            {"M001", new Predmet("M001", "Uvod do elektronove mikroskopie")},
            {"P001", new Predmet("P001", "Programovani C# 1")},
            {"P002", new Predmet("P002", "Programovani C# 2", new List<string> {"P001"})}
        };

            // pridame jeste dalsi predmety
            katalogPredmetu.Add("P020", new Predmet("P020", "Vyvoj mobilnich aplikaci", new List<string> { "X111" }));
            katalogPredmetu.Add("P021", new Predmet("P021", "Vyvoj aplikaci pro elektronove mikroskopy", new List<string> { "M001", "P002" }));
            // 4. pridej jeste dalsi predmety, aspon jeden bez prerekvizit a jeden s prerekvizitou
            katalogPredmetu.Add("P030", new Predmet("P030", "Principy programovacích jazyků a OOP", new List<string> { "X111" }));
            katalogPredmetu.Add("P031", new Predmet("P031", "Programovani C# 3", new List<string> { "P001", "P002" }));

            // 5. v metode ZkontrolujKatalog prover, jestli vsechny predmety katalogu maji v prerekvizitach existujici predmety
            // vypis chyby v nasledujicim formatu:
            //     Predmet <nazev> obsahuje neexistujici prerekvizitu: <kod>
            ZkontrolujKatalog(katalogPredmetu);


            // 6. najdi v seznamu studenta s prijmenim Novak, uloz ho do promenne studentNovak
            Student studentNovak = seznamStudentu.Find(x => x.Jmeno.Contains("Jan") && x.Prijmeni.Contains("Novak"));

            // 7. naimplementuj metodu ZapisPredmet
            // ktera zapise danemu studentovi predmet (tedy ulozi kod predmetu do jeho seznamu ZapsaneAbsolvovanePredmety)
            // pokud predmet existuje v katalogu a pokud ma student uz zapsane vsechny prerekvizity
            // vypis uspesne zapsani nebo chybu v nasledujicim formatu:
            //     <jmeno>, <prijemni>: Uspesne zapsany predmet <nazev>
            //     <jmeno>, <prijemni>: Nebylo mozno zapsat predmet <nazev> (chybi prerekvizita)
            //     <jmeno>, <prijemni>: Nebylo mozno zapsat predmet <kod> (neexistujici predmet)
            ZapisPredmet(studentNovak, "P001");
            //ZapisPredmet(studentNovak, "P002");
            ZapisPredmet(studentNovak, "P030");
            ZapisPredmet(studentNovak, "M001");
            ZapisPredmet(studentNovak, "P031");
            ZapisPredmet(studentNovak, "X222");

            bool maZapsany = studentNovak.ZapsaneAbsolvovanePredmety.Contains(new Predmet("P030", "Principy programovacích jazyků a OOP", new List<string> { "X111" }));
            Console.WriteLine(maZapsany);
        }

        private void ZkontrolujKatalog(Dictionary<string, Predmet> katalog)
        {
            foreach (Predmet predmet in katalogPredmetu.Values)
            {
                foreach (string kod in predmet.PrerekvizityKod)
                {
                    if (!katalogPredmetu.ContainsKey(kod))
                    {
                        Console.WriteLine($"Predmet {predmet.Jmeno} obsahuje neexistujici prerekvizitu: {kod}");
                    }
                }
            }
        }

        private void ZapisPredmet(Student student, string kodPredmetu)
        {
            if (katalogPredmetu.ContainsKey(kodPredmetu))
            {
                Predmet predmet = katalogPredmetu[kodPredmetu];
                foreach (string kod in predmet.PrerekvizityKod)
                {
                    if (katalogPredmetu.ContainsKey(kod) && !student.ZapsaneAbsolvovanePredmety.Contains(katalogPredmetu[kod]))
                    {
                        Console.WriteLine($"{student.Jmeno}, {student.Prijmeni}: Nebylo mozno zapsat predmet {predmet.Jmeno} (chybi prerekvizita)");
                        return;
                    }
                }
                student.ZapsaneAbsolvovanePredmety.Add(predmet);
                Console.WriteLine($"{student.Jmeno}, {student.Prijmeni}: Uspesne zapsany predmet {predmet.Jmeno}");
            }
            else
            {
                Console.WriteLine($"{student.Jmeno}, {student.Prijmeni}: Nebylo mozno zapsat predmet {kodPredmetu} (neexistujici predmet)");
            }
            
        }
    }
}
