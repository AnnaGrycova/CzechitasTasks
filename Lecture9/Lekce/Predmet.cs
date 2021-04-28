using System;
using System.Collections.Generic;

namespace Lesson09
{
    public class Predmet
    {
        public string Kod;
        public string Jmeno;
        public List<string> PrerekvizityKod; // co musi by splneno nebo aspon zapsano zaroven

        public Predmet(string kod, string jmeno)
        {
            Kod = kod;
            Jmeno = jmeno;
            PrerekvizityKod = new List<string>();
        }

        public Predmet(string kod, string jmeno, List<string> prerekvizity)
        {
            Kod = kod;
            Jmeno = jmeno;
            PrerekvizityKod = prerekvizity;
        }

        public override string ToString()
        {
            return String.Format("[{0}] {1}", Kod, Jmeno);
        }
    }
}