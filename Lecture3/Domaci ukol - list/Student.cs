using System;
using System.Collections.Generic;
using System.Text;

namespace Domaci_ukol___list
{
    class Student
    {
        public string Jmeno;
        public string Prijmeni;
        public List<Predmet> ZapsaneAbsolvovanePredmety;

        public Student(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            ZapsaneAbsolvovanePredmety = new List<Predmet>();
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Prijmeni, Jmeno);
        }
    }
}
