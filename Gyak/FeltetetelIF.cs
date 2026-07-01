using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak
{
    internal class FeltetetelIF
    {
        public static void Dara()
        {
            Console.Write("Kérek egy megy egy szamot: ");
            var inputSzam = Console.ReadLine();
            var numerikusSzam = Convert.ToInt32(inputSzam);
            var maradek = numerikusSzam % 2;
            var paros = maradek == 0;
            Console.WriteLine(paros);

            string szia;
            if (paros)
            {
                Console.WriteLine("A szám páros");
                szia = "Szia";
            }
            else
            {
                Console.WriteLine("A szám nem páros");
                //Console.WriteLine(szia); // Ez hibát fog dobni, mert a szia változó nincs inicializálva az else ágban
            }
            //Console.WriteLine(szia); // Ez hibát fog dobni, mert a szia változónak (lehetséges hogy) nincs értéke, ha a szám nem páros

            var szam = 234;
            var paros2 = szam % 2 == 0;
            if (paros2)
            {
                Console.WriteLine("Alma");
            }
            else if (szam % 3 == 0)
            {
                Console.WriteLine("Korte");
            }
            else if (szam % 3 == 0 && szam % 2 == 0)
            {
                Console.WriteLine("Korte");
            }
            else
            {
                Console.WriteLine("Semire se igaz");
            }
        }
    }
}
