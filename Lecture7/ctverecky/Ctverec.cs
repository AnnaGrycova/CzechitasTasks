using System;

namespace Lesson07
{
    public class Ctverec : Obdelnik
    {
        public double Delka
        {
            get { return vyska; }
            set
            {
                vyska = value;
                sirka = value;
            }
        }
    }
}
