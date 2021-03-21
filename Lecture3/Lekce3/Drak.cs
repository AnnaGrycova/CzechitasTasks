using System;
using System.Collections.Generic;
using System.Text;

namespace Lekce3
{
    public class Drak
    {
        public int Sila;
        public int Zivot;

        public Drak(int sila, int zivot)
        {
            Sila = sila;
            Zivot = zivot;
        }

        public override string ToString()
        {
            return string.Format("drak -- zivot:{0} sila:{1}", Zivot, Sila);
        }

        public bool JeNazivu()
        {
            return Zivot > 0;
        }

        public void Zautoc(Rytir rytir)
        {
            rytir.Zivot -= Sila;
        }
    }


}
