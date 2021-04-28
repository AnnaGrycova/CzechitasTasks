using System;
using System.Collections.Generic;

namespace Lesson05
{
    public class Prihlasovani
    {
        private List<Student> seznamStudentu;
        private Dictionary<string, Predmet> katalogPredmetu;

        public Prihlasovani()
        {
            // 1. nejprve vytvor novy prazdny seznam studentu a uloz ho do promenne seznamStudentu
            seznamStudentu = new List<Student>();

            // naplnime studenty
            seznamStudentu.Add(new Student("Jan", "Novak"));
            seznamStudentu.Add(new Student("Petra", "Svobodova"));
            // 2. pridej nekolik dalsich studentu
            seznamStudentu.Add(new Student("Ales", "Novotny"));
            seznamStudentu.Add(new Student("Lucie", "Prochazkova"));
            seznamStudentu.Add(new Student("Marie", "Konecna"));

            // 3. vypis seznam studentu na konzoli
            Console.WriteLine("-- seznam studentu:");
            foreach (var student in seznamStudentu)
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
            katalogPredmetu.Add("P020", new Predmet("P020", "Vyvoj mobilnich aplikaci", new List<string> {"X111"}));
            katalogPredmetu.Add("P030", new Predmet("P030", "Vyvoj aplikaci pro elektronove mikroskopy", new List<string> {"M001", "P002"}));
            // 4. pridej jeste dalsi predmety, aspon jeden bez prerekvizit a jeden s prerekvizitou
            katalogPredmetu.Add("M010", new Predmet("M010", "Vakuum v elektronove mikroskopii", new List<string> {"M001"}));
            katalogPredmetu.Add("P010", new Predmet("P010", "Programovani Python"));
            katalogPredmetu.Add("X123", new Predmet("X456", "Testovani software"));

            // 5. v metode ZkontrolujKatalog prover, jestli vsechny predmety katalogu maji v prerekvizitach existujici predmety
            // vypis chyby v nasledujicim formatu:
            //     Predmet <nazev> obsahuje neexistujici prerekvizitu: <kod>
            //     Predmet <nazev> (<kod>) ulozen do katalogu pod chybnym kodem: <klicSlovniku>
            ZkontrolujKatalog(katalogPredmetu);


            // 6. najdi v seznamu studenta s prijmenim Novak, uloz ho do promenne studentNovak
            Student studentNovak = seznamStudentu.Find(s => s.Prijmeni.Equals("Novak"));


            // 7. naimplementuj metodu ZapisPredmet
            // ktera zapise danemu studentovi predmet (tedy ulozi kod predmetu do jeho seznamu ZapsaneAbsolvovanePredmety)
            // pokud predmet existuje v katalogu a pokud ma student uz zapsane vsechny prerekvizity
            // vypis uspesne zapsani nebo chybu v nasledujicim formatu:
            //     <jmeno>, <prijemni>: Uspesne zapsany predmet <nazev>
            //     <jmeno>, <prijemni>: Nebylo mozno zapsat predmet <nazev> (chybi prerekvizita)
            //     <jmeno>, <prijemni>: Nebylo mozno zapsat predmet <kod> (neexistujici predmet)
            Console.WriteLine("-- zapis predmetu:");
            ZapisPredmet(studentNovak, "P001");
            ZapisPredmet(studentNovak, "P002");
            ZapisPredmet(studentNovak, "P030");
            ZapisPredmet(studentNovak, "M001");
            ZapisPredmet(studentNovak, "P030");
            ZapisPredmet(studentNovak, "X222");


            Vyucujici vyucujici = new Vyucujici("Albus", "Brumbal");
            var jmeno = vyucujici.Jmeno;
            //vyucujici.Jmeno = "Sirius"; // nejde, setter je protected

            Console.WriteLine("-- vyucujici:");
            Console.WriteLine(vyucujici);

            vyucujici.PrihlasSeDoSkolnihoSystemu();
            studentNovak.PrihlasSeDoSkolnihoSystemu();

            Osoba osoba = vyucujici;
            osoba.PrihlasSeDoSkolnihoSystemu();
            osoba = studentNovak;
            osoba.PrihlasSeDoSkolnihoSystemu();

            //osoba = new Osoba("", ""); // Nejde. Ma protected konstruktor... a je to abstraktni trida

            var absolvent = new Absovent("Jaroslav", "Moudry", 2015);
            absolvent.PrihlasSeDoSkolnihoSystemu();
        }

        private void ZkontrolujKatalog(IReadOnlyDictionary<string, Predmet> katalog)
        {
            Console.WriteLine("-- kontrola katalogu predmetu:");

            // === KONTROLA KODU V KLICI A V INSTANCI PREDMETU ===
            // prochazim kolekci klicu katalogu
            // do promenne kdoPredmetu dostanu kod pochazejici z klice
            foreach (var kodPredmetu in katalogPredmetu.Keys)
            {
                // pro kazdy predmet si zamapatuju cely objekt predmetu
                var predmet = katalog[kodPredmetu];

                // porovnam kod 
                if (kodPredmetu != predmet.Kod)
                {
                    // vypisu chybovou hlasku, kdyz se lisi
                    Console.WriteLine(String.Format("Predmet {0} ({1}) ulozen do katalogu pod chybnym kodem: {2}",
                        predmet.Jmeno, predmet.Kod, kodPredmetu));
                }
            }

            // === KONTROLA PREREKVIZIT VSECH PREDMETU ===
            // prochazim kolekci hodnot katalogu 
            // do promenne predmet dostanu instanci typu Predmet
            foreach (var predmet in katalog.Values)
            {
                foreach (var prerekvizita in predmet.PrerekvizityKod)
                {
                    if (!katalog.ContainsKey(prerekvizita))
                    {
                        Console.WriteLine(String.Format("Predmet {0} obsahuje neexistujici prerekvizitu: {1}",
                            predmet.Jmeno, prerekvizita));
                    }
                }
            }

            /*
            // druha moznost kontroly prerekvizit
            // prochazim katalog tak, ze uvnitr cyklu foreach mam dvojici-klic-hodnota (keyValuePair)
            // obsahujici v sobe jak kod tak cely objekt typu predmet
            // pristupuje se k nim keyValuePair.Key a keyValuePair.Value
            foreach (KeyValuePair<string, Predmet> keyValuePair in katalog)
            {
                foreach (var prerekvizita in keyValuePair.Value.PrerekvizityKod)
                {
                    if (!katalog.ContainsKey(prerekvizita))
                    {
                        Console.WriteLine(String.Format("Predmet {0} obsahuje neexistujici prerekvizitu: {1}",
                            keyValuePair.Value.Jmeno, prerekvizita));
                    }
                }
            }
            */
        }

        private void ZapisPredmet(Student student, string kodPredmetu)
        {
            // === KONTROLA, jestli predmet existuje v katalogu
            if (!katalogPredmetu.ContainsKey(kodPredmetu))
            {
                Console.WriteLine(String.Format("{0}, {1}: Nebylo mozno zapsat predmet {2} (neexistujici predmet)",
                    student.Prijmeni, student.Jmeno, kodPredmetu));
                return;
            }
            // ted je jasne, ze katalog obsahuje takovyto predmet, vytahnu si ho z katalogu
            var predmet = katalogPredmetu[kodPredmetu];


            // === KONTROLA, jestli ma student splneny prerekvizity
            // zkopiruju vsechny prerekvizity do noveho seznamu, budu vymazavat ty splnene
            var prerekvizityMusiBytSplneny = new List<string>(predmet.PrerekvizityKod);

            foreach (var splnenaPrerekvizita in student.ZapsaneAbsolvovanePredmety)
            {
                if (prerekvizityMusiBytSplneny.Contains(splnenaPrerekvizita.Kod))
                {
                    prerekvizityMusiBytSplneny.Remove(splnenaPrerekvizita.Kod);
                }
            }

            // kdyz v seznamu neco zustalo, je to nesplnena prerekvizita
            if (prerekvizityMusiBytSplneny.Count > 0)
            {
                Console.WriteLine(String.Format("{0}, {1}: Nebylo mozno zapsat predmet {2} (chybi prerekvizita)",
                    student.Prijmeni, student.Jmeno, predmet.Jmeno));
                return;
            }

            // === PODMINKY SPLNENY, proved zapis
            student.ZapsaneAbsolvovanePredmety.Add(predmet);

            Console.WriteLine(String.Format("{0}, {1}: Uspesne zapsany predmet {2}",
                student.Prijmeni, student.Jmeno, predmet.Jmeno));
        }
    }
}