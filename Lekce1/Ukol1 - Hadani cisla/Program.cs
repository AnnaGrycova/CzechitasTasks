using System;

namespace Ukol1___Hadani_cisla
{
    class Program
    {
        static void Main(string[] args)
        {
            int rnd = Generate();
            int input;
            do
            {
                Console.WriteLine("Jake cislo si myslim?");
                bool isNumber = int.TryParse(Console.ReadLine(), out input);
                if (!isNumber)
                {
                    Console.WriteLine("Zadany vstup neni cislo");
                    //continue; break by vylezl z while/for cyklu, continue se vrati na zacatek cyklu a return by vylezl z metody
                }
                else if (input < rnd)
                {
                    Console.WriteLine("Cislo je vetsi, hadej znovu.");
                }
                else if (input > rnd)
                {
                    Console.WriteLine("Cislo je mensi, hadej znovu.");
                }
                else
                {
                    Console.WriteLine("To je správně");
                }
            }
            while (input != rnd);
        }
        public static int Generate()
        {
            Random random = new Random();
            return random.Next(0, 100);            
        }
    }
}
