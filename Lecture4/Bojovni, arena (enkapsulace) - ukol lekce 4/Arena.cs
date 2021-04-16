using System;
using System.Collections.Generic;
using System.Text;

namespace Bojovni__arena__enkapsulace____ukol_lekce_4
{
// 5. Vytvořte třídu Arena
// 6. Vytvořte v Arene funkci, ktera zobrazi stav bojovniku v areně.
// 7. V Arene vytvořte metodu boj, která spustí zápas mezi dvěma bojovníky a zobrazí stav před a po souboji.

//==============================================
//Fidel Zivot: 100 Brneni:  20
//Horal Zivot: 100 Brneni:   0
//==============================================
//Horal Zivot:   4 Brneni:   0


    class Arena
    {
        public List<Bojovnik> seznamBojovniku = new List<Bojovnik>();
        Random random = new Random();

        public void RegistrujBojovnika(Bojovnik bojovnik)
        {
            if (bojovnik != null && !seznamBojovniku.Contains(bojovnik))
            {
                seznamBojovniku.Add(bojovnik);
            }
        }

        public void Boj()
        {
            List<Bojovnik> ziviBojovnici = new List<Bojovnik>(seznamBojovniku);
            while (ziviBojovnici.Count > 1)
            {
                ZobrazStavBojovniku();
                List<List<Bojovnik>> seznamParuBojovniku = VylosujBojovniky(ziviBojovnici);
                foreach (List<Bojovnik> parBojovniku in seznamParuBojovniku)
                {
                    BojParu(parBojovniku[0], parBojovniku[1]);
                    //_ = parBojovniku[0].JeZivy ? ziviBojovnici.Remove(parBojovniku[1]) : ziviBojovnici.Remove(parBojovniku[0]);

                    if (!parBojovniku[0].JeZivy)
                    {
                        ziviBojovnici.Remove(parBojovniku[0]);
                    }
                    else
                    {
                        ziviBojovnici.Remove(parBojovniku[1]);
                    }
                }
            }
            ZobrazStavBojovniku();
        }

        public void BojParu(Bojovnik vyzyvatel, Bojovnik souper)
        {

            while (vyzyvatel.JeZivy && souper.JeZivy)
            {
                List<Bojovnik> bojovniciProNahodnePoradi = new List<Bojovnik>
                    {
                    vyzyvatel,
                    souper
                    };
                int index1 = random.Next(bojovniciProNahodnePoradi.Count);
                int index2 = index1 == 0 ? 1 : 0;
                
                bojovniciProNahodnePoradi[index1].UtocNa(bojovniciProNahodnePoradi[index2]);
                if (bojovniciProNahodnePoradi[index2].JeZivy)
                {
                    bojovniciProNahodnePoradi[index2].UtocNa(bojovniciProNahodnePoradi[index1]);
                }
            }

        }

        public List<List<Bojovnik>> VylosujBojovniky(List<Bojovnik> ziviBojovnici)
        {
            List<List<Bojovnik>> seznamParuBojovniku = new List<List<Bojovnik>>();
            List<Bojovnik> losovaniBojovnici = new List<Bojovnik>(ziviBojovnici);
            while (losovaniBojovnici.Count >= 2)
            {
                List<Bojovnik> paryBojovniku = new List<Bojovnik>();

                for (int i = 0; i < 2; i++)
                {
                    int index = random.Next(losovaniBojovnici.Count);
                    //Console.WriteLine($"{index} {losovaniBojovnici[index].Jmeno}");
                    paryBojovniku.Add(losovaniBojovnici[index]);
                    losovaniBojovnici.Remove(losovaniBojovnici[index]);
                }
                seznamParuBojovniku.Add(paryBojovniku);
            }
            return seznamParuBojovniku;
        }


        public void ZobrazStavBojovniku(bool zahrnoutMrtve = true)
        {            
            foreach (Bojovnik bojovnik in seznamBojovniku)
            {
                if (zahrnoutMrtve || bojovnik.JeZivy)
                {
                    Console.WriteLine(bojovnik.VratStav());
                }
            }
            Console.WriteLine("".PadLeft(20, '='));
        }

        //public void Boj(Bojovnik bojovnik1, Bojovnik bojovnik2)
        //{
        //    Console.WriteLine("==========================================");
        //    ZobrazStavBojovniku();
        //    Console.WriteLine("==========================================");
        //    while (bojovnik1.JeZivy && bojovnik2.JeZivy)
        //    {
        //        bojovnik1.UtocNa(bojovnik2);
        //        if (bojovnik2.JeZivy)
        //        {
        //            bojovnik2.UtocNa(bojovnik1);
        //        }
        //    }
        //    ZobrazStavBojovniku(false);            
        //}
    }
}
