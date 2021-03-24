using System;
using System.Collections.Generic;
using System.Text;

namespace Domaci_ukol___list
{
    class Predmet
    {
        public string Kod;
        public string Jmeno;
        public List<string> PrerekvizityKod; // co musi by splneno nebo aspon zapsano zaroven

        public Predmet(string kod, string jmeno)
        {
            //je zde prazdny list, proto mohu iterovat ve foreach, jinak by to spadlo
            Kod = kod; Jmeno = jmeno; PrerekvizityKod = new List<string>();
        }

        public Predmet(string kod, string jmeno, List<string> prerekvizity)
        {
            Kod = kod; Jmeno = jmeno; PrerekvizityKod = prerekvizity;
        }

        //public override bool Equals(Object predmet)
        //{
        //    return Kod == ((Predmet)predmet).Kod;
        //}
    }
}
