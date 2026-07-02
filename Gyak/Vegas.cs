using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak
{
    internal class Vegas
    {
        public static void Dara()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        continue;
            //    }

            //    if (i > 6)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(i);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        if (i > 6)
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine(i);
            //        }
            //    }
            //}

            var penz = 1000;
            var rng = new Random();
            while (penz > 0)
            {
                Console.WriteLine("A pénzed: " + penz + " Ft");
                Console.Write("Mennyi pénz akarsz felrakni: ");
                var tet = Console.ReadLine();
                var tetInt = Convert.ToInt32(tet);
                penz -= tetInt;

                Console.WriteLine("Mit játszunk: ");
                var valasztas = Console.ReadLine();

                var randomSzam = rng.Next(1, 100);
                if (valasztas == "paros")
                {
                    if (randomSzam % 2 == 0)
                    {
                        Console.WriteLine("Nyertél! A szám: " + randomSzam);
                        penz += tetInt * 2;
                    }
                    else
                    {
                        Console.WriteLine("Vesztettél! A szám: " + randomSzam);
                    }
                }
                else if (valasztas == "paratlan")
                {
                    if (randomSzam % 2 != 0)
                    {
                        Console.WriteLine("Nyertél! A szám: " + randomSzam);
                        penz += tetInt * 2;
                    }
                    else
                    {
                        Console.WriteLine("Vesztettél! A szám: " + randomSzam);
                    }
                }
                else if (valasztas == "vege")
                {
                    break;
                }
                else
                {
                    // bizunk benne hogy minden más az szám
                    var valasztasSzam = Convert.ToInt32(valasztas);
                    if (valasztasSzam == randomSzam)
                    {
                        Console.WriteLine("Nyertél! A szám: " + randomSzam);
                        penz += tetInt * 37;
                    }
                    else
                    {
                        Console.WriteLine("Vesztettél! A szám: " + randomSzam);
                    }
                }
            }
        }
    }
}
