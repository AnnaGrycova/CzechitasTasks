using System;

namespace Lesson09
{
    public class Vyucujici : Osoba
    {
        public Vyucujici(string jmeno, string primeni) : base(jmeno, primeni)
        {
        }

        public Vyucujici(string jmeno, string primeni, string email) : base(jmeno, primeni)
        {
            Email = email;
        }

        public override void PrihlasSeDoSkolnihoSystemu() // pretezuji obecne prihlasovani...
        {
            Console.WriteLine("Ano, je porad zamestnancem university");
            base.PrihlasSeDoSkolnihoSystemu();            // ale to obecne prihlasovani pouziju, zavolam
        }

        public override void NaobedvejSe()
        {
            // nobl restaurace
        }

        public bool MaRadSvestky()
        {
            return Prijmeni.Length > 6;
        }
    }
}
