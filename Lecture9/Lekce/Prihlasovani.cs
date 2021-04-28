using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson09
{
    public class Prihlasovani
    {
        private List<Student> seznamStudentu;
        private Dictionary<string, Predmet> katalogPredmetu;

        private Student NajdiDruhyPrvek(IReadOnlyList<Student> students)
        {
            return students[1];
        }

        public Prihlasovani()
        {
            seznamStudentu = new List<Student>
            {
                new Student("Jan", "Novak"),
                new Student("Petra", "Svobodova"),
                new Student("Ales", "Novotny"),
                new Student("Lucie", "Prochazkova"),
                new Student("Marie", "Konecna")
            };

            var first = seznamStudentu.First();
            var secondAndOn = seznamStudentu.Skip(1).ToList();
            var secondByLinq = seznamStudentu.Skip(1).First(); // Take(3)

            var threeStudents = seznamStudentu.TakeWhile(s => s.Prijmeni.StartsWith("N"));

            var second = seznamStudentu.Second();

            var druhyStudent = NajdiDruhyPrvek(seznamStudentu);

            var studentiSKratkymJmenem = seznamStudentu.Where(student => student.Jmeno.Length < 5);

            //studenti, jejichz Prijmeni zacina na N
            var studentiNaN = seznamStudentu.Where(student => student.Prijmeni.StartsWith("N"));

            var krestniJmena = seznamStudentu.Select(s => s.Jmeno + " <---");

            var jmeeena = seznamStudentu
                .Where(student => student.Prijmeni.StartsWith("N"))
                .OrderBy(s => s.Prijmeni) //.OrderByDescending()
                .Select(s => s.Jmeno + " <---");

            var sqlLikeNames = 
                from s in seznamStudentu
                where s.Prijmeni.StartsWith("N")
                select s.Jmeno + " <-------";

            Console.WriteLine("-- seznam studentu:");
            foreach (var student in threeStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("-- skupiny podle krestniho jmena:");
            seznamStudentu.Add(new Student("Jan", "Dvorak"));
            var skupinyPodleJmena = seznamStudentu.GroupBy(s => s.Jmeno);

            foreach (var skupina in skupinyPodleJmena)
            {
                Console.WriteLine($"* skupina {skupina.Key}");

                foreach (var student in skupina)
                {
                    Console.WriteLine(student);
                }
            }


            // vytvorime katalog predmetu, vytvorime nejake predmety
            katalogPredmetu = new Dictionary<string, Predmet>
            {
                {"M001", new Predmet("M001", "Uvod do elektronove mikroskopie")},
                {"P001", new Predmet("P001", "Programovani C# 1")},
                {"P002", new Predmet("P002", "Programovani C# 2", new List<string> {"P001"})},
                {"P020", new Predmet("P020", "Vyvoj mobilnich aplikaci", new List<string> {"X111"})},
                {"P030", new Predmet("P030", "Vyvoj aplikaci pro elektronove mikroskopy", new List<string> {"M001", "P002"})},
                {"M010", new Predmet("M010", "Vakuum v elektronove mikroskopii", new List<string> {"M001"})},
                {"P010", new Predmet("P010", "Programovani Python")},
                {"X123", new Predmet("X456", "Testovani software")}
            };

            var prvniPredmet = katalogPredmetu.First(); //LINQ
            var druhyPredmet = katalogPredmetu.Second(); //my extension method

            //VYPIS
            //vsechny predmety, jejichz jmeno zacina na P
            //vsechy kody (jen kody) ktere NEzacinaji na P
            //nazev prvniho predmetu, ktery ma nejake prerekvizity
            //vsechny predmety, ktere maji prerekvizitu M001

            var col1 = katalogPredmetu.Where(p => p.Value.Jmeno.StartsWith("P")).Select(p => p.Value);
            var col2 = katalogPredmetu.Where(p => !p.Key.StartsWith("P")).Select(p => p.Key);
            var col3 = katalogPredmetu.First(p => p.Value.PrerekvizityKod.Count > 0);
            var col4 = katalogPredmetu.Where(p => p.Value.PrerekvizityKod.Contains("M001")).Select(p => p.Value);

            Console.WriteLine("-- katalog:");
            Console.WriteLine(String.Join(Environment.NewLine, col3));

            var valid = katalogPredmetu.All(p => p.Key == p.Value.Kod);
            var anyInvalid = katalogPredmetu.Any(p => p.Key != p.Value.Kod);

            ZkontrolujKatalog(katalogPredmetu);


            Student studentNovak = seznamStudentu.Find(s => s.Prijmeni.Equals("Novak"));


            Console.WriteLine("-- zapis predmetu:");
            ZapisPredmet(studentNovak, "P001");
            ZapisPredmet(studentNovak, "P002");
            ZapisPredmet(studentNovak, "P030");
            ZapisPredmet(studentNovak, "M001");
            ZapisPredmet(studentNovak, "P030");
            ZapisPredmet(studentNovak, "X222");


            //Union, Intersect, ...
            //https://www.tutorialsteacher.com/linq/linq-tutorials
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