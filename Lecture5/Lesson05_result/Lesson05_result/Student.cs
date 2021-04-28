using System.Collections.Generic;

namespace Lesson05
{
    public class Student : Osoba
    {
        public Student(string jmeno, string primeni) : base(jmeno, primeni)
        {
            ZapsaneAbsolvovanePredmety = new List<Predmet>();
        }

        public List<Predmet> ZapsaneAbsolvovanePredmety { get; private set; }

        public override void NaobedvejSe()
        {
            // menza
        }
    }
}
