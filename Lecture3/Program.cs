using System;
using System.Collections.Generic;

namespace Lekce3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kral chce usporadat velky turnaj
            // kterykoli rytir se muze zucastnit
            List<Rytir> seznam = new List<Rytir>
            {
                new Rytir("Vojtech"),
                new Rytir("Prokop"),
                new Rytir("Vaclav"),
                new Rytir("Vaclav"),
                new Rytir("Pajdule"),
                new Rytir("Andule"),
            };
            //seznam.Add(null);
            seznam.Add(new Rytir("Vaclav"));
            Rytir borivoj = new Rytir("Borivoj");
            //pridani dvou referenci na ten samy objekt, to ale neni bezna praxe, nedela se to
            seznam.Add(borivoj);
            seznam.Add(borivoj);
            //bude 1 Vaclav II.
            seznam[2].Jmeno = "Vaclav II.";
            //budou 2 Borivojove II.
            seznam[7].Jmeno = "Borivoj II.";
            //nebude tam stale nic, OUT OF RANGE
            //seznam[11].Jmeno = "Borivoj II.";
            // pocet prvku v seznamu, pocitaji se dva Borivojove, i kdyz to jsou reference na stejne objekty
            Console.WriteLine($"Pocet rytiru v seznamu: {seznam.Count}");
            Console.WriteLine($"Kapacita rytiru: {seznam.Capacity}");
            foreach (Rytir rytir in seznam)
            {
                if (rytir.Zivot < 100)
                {
                    Console.Write("--> ");
                }
                Console.WriteLine(rytir);
            }
            //odstrani se prvni Borivoj v seznamu
            seznam.Remove(borivoj);
            Console.WriteLine();
            foreach (Rytir rytir in seznam)
            {
                Console.WriteLine(rytir);
            }
            Console.WriteLine();
            //LAMBDA EXPRESSION jakoby z funkce, ktera by rozhodovala stejne
            //static bool ZacinaNaP(Rytir rytir) { return rytir.Jmeno.StartsWith("P"); }
            Rytir rytirNaP = seznam.Find(rytir => rytir.Jmeno.StartsWith("P"));
            Console.WriteLine(rytirNaP);
            var rytiri = seznam.FindAll(rytir => rytir.Jmeno.StartsWith("P"));
            Console.WriteLine();
            //proiteruje to rytire a zavola na nich ToString a spoji jednotlive vysledky
            //ToString a da mezi kazde rytire da NewLine (\n)
            Console.WriteLine(String.Join(Environment.NewLine, rytiri));
            rytiri = seznam.FindAll(rytir => rytir.Jmeno.StartsWith("V"));
            Console.WriteLine();
            foreach (Rytir rytir in rytiri)
            {
                Console.WriteLine(rytir);
            }
            var rytiri2 = seznam.FindAll(rytir => rytir.Zivot < 105);
            Console.WriteLine();
            Console.WriteLine(String.Join(/*Environment.NewLine*/'\n', rytiri2));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // vytvoreni slovniku
            Dictionary<string, Rytir> soupiskaRytiru = new Dictionary<string, Rytir>
            {
                { "Vaclav", new Rytir("Vaclav") },
                { "Rostislav", new Rytir("Rostislav") },
            };
            // pristup k jeho prvku, uz to nelze vyhledat podle indexu 0, neni to serazene a neni garantovane poradi pri proiterovani
            var rytirVaclav = soupiskaRytiru["Vaclav"];
            Console.WriteLine(rytirVaclav);
            // iterace pres vsechny klice slovniku
            //vytvarim promennou jmenoRytire, ktera je viditelna jen uvnitr foreach
            //do jmenoRytire si ukladam klic
            foreach (var jmenoRytire in soupiskaRytiru.Keys)
            {
                Console.WriteLine(jmenoRytire);
            }
            // dotaz, jestli je zaznam k dispozici
            if (soupiskaRytiru.ContainsKey("Vaclav"))
            {
                Console.WriteLine("Nasel jsem Vaclava");
            }
            // pridani zaznamu do slovniku
            soupiskaRytiru.Add("Prokop", new Rytir("Prokop"));
            //lepsi:
            soupiskaRytiru["Spytihnev"] = new Rytir("Spytihnev");
            Console.WriteLine();
            // iterace pres vsechny objekty ulozene ve slovniku
            foreach (var rytir in soupiskaRytiru.Values)
            {
                Console.WriteLine(rytir);
            }

            static void Boj(Rytir r1, Rytir r2)
            {
                int score1 = r1.BojujNaTurnaji(r2);
                int score2 = r2.BojujNaTurnaji(r1);

                if (score1 == score2)
                {
                    Console.WriteLine(String.Format("Remiza mezi {0} a {1}", r1.Jmeno, r2.Jmeno));
                }
                else if (score1 > score2)
                {
                    Console.WriteLine(String.Format("{0} vyhral nad {1}", r1.Jmeno, r2.Jmeno));
                }
                else
                {
                    Console.WriteLine(String.Format("{0} prohral s {1}", r1.Jmeno, r2.Jmeno));
                }
            }

            static bool ZacinaNaP(Rytir rytir)
            {
                return rytir.Jmeno[0] == 'P';
            }

            //Program.Main2(args);
        }

        static void Main2(string[] args)
        {
            Drak drak = new Drak(32, 200);
            Console.WriteLine("Priletel k nam drak!");

            Rytir[] seznamRytiru = new Rytir[6]; // pole (array) instanci typu Rytir

            seznamRytiru[0] = new Rytir(9, 100); // Vojtech   POZOR, zacina se od indexu 0
            seznamRytiru[1] = new Rytir(12, 80); // Prokop
            seznamRytiru[2] = new Rytir(11, 110); // Borivoj
            seznamRytiru[3] = new Rytir(14, 100); // Vaclav
            seznamRytiru[4] = new Rytir(12, 130); // Stanislav
            seznamRytiru[5] = new Rytir(8, 100); // Spytihnev

            Console.WriteLine("Kral povolal pul tuctu rytiru, aby s drakem bojovali");

            int kolikatyRytir = 0;

            // cela patalie s drakem -- rytiri jdou postupne bojovat s drakem, dokud je drak nazivu (nebo dokud mame rytire na seznamu)
            while (drak.JeNazivu() && kolikatyRytir < seznamRytiru.Length && seznamRytiru[kolikatyRytir] != null)
            {
                Console.WriteLine();
                Console.WriteLine("Drakova aktualni kondice " + drak);

                Rytir rytirKteryPraveBojuje = seznamRytiru[kolikatyRytir];
                Console.WriteLine("Bojovat s nim bude " + rytirKteryPraveBojuje);

                // jeden souboj -- tak dlouho, dokud jsou drak i rytir nazivu
                while (rytirKteryPraveBojuje.JeNazivu() && drak.JeNazivu())
                {
                    // jedno kolo souboje -- rytir zautoci a pak drak zautoci
                    rytirKteryPraveBojuje.Zautoc(drak);
                    drak.Zautoc(rytirKteryPraveBojuje);

                    Console.WriteLine(drak);
                    Console.WriteLine(rytirKteryPraveBojuje);
                }

                kolikatyRytir++;
            }


            Console.WriteLine();
            Console.WriteLine("Vsichni rytiri: ");

            // vnitrek cyklu foreach se provede prave tolikrat, kolik je prvku v ridicim poli (seznamRytiru)
            // uvnitr cyklu v promenne aktualniRytir budu mit postupne vsechny prvky pole
            foreach (Rytir aktualniRytir in seznamRytiru)
            {
                if (aktualniRytir != null)
                {
                    Console.Write(aktualniRytir);
                    if (!aktualniRytir.JeNazivu())
                    {
                        Console.Write(" (cest jeho pamatce!)");
                    }
                    Console.WriteLine();
                }
            }


            Console.ReadLine();
        }
    }   
}
