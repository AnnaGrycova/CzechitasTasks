using System;
using System.Collections.Generic;
using System.Text;

namespace Bojovni__arena__enkapsulace____ukol_lekce_4
{
    //1. Vytvořte třídu Bojovnik, která bude mít properties Jmeno, Sila, Brneni, Zivot.Properties nesmí být možné změnit mimo třídu.
    //2. Síla musí být vždy alespoň 10, Život 0 až 100, Brnění 0 až 50
    //3. Bojovníkovi vytvořte metodu UtocNa, která provede útok na jiného bojovníka.
    //   - útok odečte protivníkovi ze života sílu aktuálního bojovníka.
    //4. Přidejte bojovníkovi další property nebo funkce/metody podle potřeby (např.může se hodit JeZivy apod)

    //10. Rozšiřte metodu UtocNa, která provede útok na jiného bojovníka.
    //- podle typu zbraně se provede útok následovně
    //Mec
    //- cíl nemá brnění - útok je roven síle
    //- cíl má brnění > 0 - útok se snižuje o velikost brnění
    //- Vždy poškodí brnění o desetinu síly, dokud není úplně zničené.
    //Palcat
    //- útok je vždy roven čtvrtině síly 
    //- vždy poškodí brnění o čtvrtinu síly, dokud není úplně zničené.

//==============================================
//Fidel Zbran:     Palcat Zivot: 100 Brneni:  20
//Horal Zbran:     Palcat Zivot: 100 Brneni:   0
//==============================================
//Horal Zbran:     Palcat Zivot:   4 Brneni:   0

    class Bojovnik
    {
        public string Jmeno { get; private set; }
        public int Sila { get; private set; }
        public Zbran VybranaZbran { get; private set; }
        public double Brneni { get; private set; }
        public double Zivot { get; private set; }
   

        //keyword argumenty
        public Bojovnik(string jmeno, int sila, Zbran zbran, double brneni = 50, double zivot = 100)
        {
            this.Jmeno = jmeno;
            this.Sila = sila <= 10 ? 10 : sila;
            this.Zivot = (zivot < 0 || zivot > 100) ? 100 : zivot;
            this.Brneni = (brneni < 0 || brneni > 50) ? 50 : brneni;
            this.VybranaZbran = zbran;
        }

        public void UtocNa(Bojovnik bojovnikObet)
        {
            bojovnikObet.DejPoskozeniUtokem(this.Sila, this.VybranaZbran);
            if (bojovnikObet.Zivot < 0)
            {
                bojovnikObet.Zivot = 0;
            }
            if (bojovnikObet.Brneni < 0)
            {
                bojovnikObet.Brneni = 0;
            }
        }

        private void DejPoskozeniUtokem(int silaUtoku, Zbran zbran)
        {
            switch (zbran)
            {
                case Zbran.Mec:
                    this.Zivot -= this.Brneni > 0 ? Math.Abs(silaUtoku - this.Brneni) : silaUtoku;
                    this.Brneni -= silaUtoku / 10;
                    break;
                case Zbran.Palcat:
                    this.Zivot -= silaUtoku * 2;
                    this.Brneni -= silaUtoku / 5;
                    break;
                case Zbran.Kyj:
                    this.Zivot -= silaUtoku * 1.5;
                    this.Brneni -= silaUtoku / 8;
                    break;
                case Zbran.Prak:
                    this.Zivot -= silaUtoku * 0.5;
                    this.Brneni -= silaUtoku / 15;
                    break;
                case Zbran.Lzicka:
                    this.Zivot -= silaUtoku * 0.2;
                    this.Brneni -= silaUtoku / 100;
                    break;
            }
            
        }

        public string VratStav()
        {
            return $"{Jmeno} Zbran: {VybranaZbran} Zivot: {Zivot} Brneni: {Brneni}";
        }

        public bool JeZivy
        {
            get
            {
                return Zivot > 0;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Jmeno == (obj as Bojovnik).Jmeno;
        }
    }
}
