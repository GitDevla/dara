using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak
{
    internal class Ciklusok
    {
        public static void Dara()
        {
            // elő-tesztelő while ciklus
            // számok összeadása 0-tól 3-ig
            // erre jobb a for ciklus
            var osszeg = 0;
            var szamlalok = 0;
            while (szamlalok < 4)
            {
                osszeg = osszeg + szamlalok;
                szamlalok = szamlalok + 1;
            }
            Console.WriteLine(osszeg);

            // szám szorzása 2-tővel amíg az eredmény kisebb mint 400
            var osszeg2 = 1;
            while (osszeg2 < 400)
            {
                osszeg2 = osszeg2 * 2;
                Console.WriteLine(osszeg2);
            }

            // után tesztelő minimum egyszer lefut és csak utána ellenőrzi a feltételt
            do
            {

            }
            while (true);

            // lépéses for ciklus
            for (int i = 0; i < 10; i++)
            {

            }

            // random szam tippelő
            var rng = new Random();
            var randomSzam = rng.Next(1, 20);
            var tippSzama = 0;
            var fut = true;
            while (fut)
            {
                Console.Write("Kérünk egy szamot: ");
                var szam = Console.ReadLine();
                var szamInt = Convert.ToInt32(szam);
                tippSzama++;
                if (szamInt == randomSzam)
                {
                    Console.WriteLine("Tippek száma: " + tippSzama);
                    Console.WriteLine("Grtual");
                    fut = false;
                }
                else if (szamInt > randomSzam)
                {
                    Console.WriteLine("Túl sok");
                }
                else if (szamInt < randomSzam)
                {
                    Console.WriteLine("Túl kevés");
                }
            }

        }
    }
}
