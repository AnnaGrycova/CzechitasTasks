using System;

namespace Lesson05
{
    public abstract class Osoba // pripadne neco jako UzivatelUniverzitnihoInformacnihoSystemu
    {
        protected Osoba(string jmeno, string primeni) //ctor tab tab
        {
            Jmeno = jmeno;
            Prijmeni = primeni;
        }

        public string Jmeno { get; protected set; }
        public string Prijmeni { get; protected set; }
        public string Email { get; set; }

        public virtual void PrihlasSeDoSkolnihoSystemu() // virtual -- potomek muze menit chovani
        {
            Console.WriteLine(string.Format("{0}: prihlasen do systemu", ToString())); // this)); // this.ToString()));
        }

        public abstract void NaobedvejSe(); // abstract -- potomek musi definovat, jak se naobedvat

        public override string ToString()
        {
            return String.Format("{0}, {1}", Prijmeni, Jmeno);
        }
    }
}
