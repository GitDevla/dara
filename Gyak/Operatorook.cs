using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak
{
    internal class Operatorook
    {
        public static void Dara()
        {
            // Operátorok
            int matematika = (5 + 3) * 2; // Tartja a PAMDAS matematikai szabályokat
            string nevem = "Dávid";
            string szoveges2 = nevem + "  a nevem."; // szöveges típusú változók összefűzése
            bool hetNagyobbMintHarom = 7 >= 3; // Logikai operátorok numerikus típusú változók összehasonlítására
                                               // < kissebb
                                               // > nagyobb
                                               // <= kissebb vagy egyenlő
                                               // >= nagyobb vagy egyenlő
                                               // == egyenlő
                                               // != nem egyenlő

            bool igazEsIgaz = true && true; // ÉS logikai operátor, mindkét oldalnak igaznak kell lennie, hogy az eredmény igaz legyen
            bool igazVagyHamis = true || false; // VAGY logikai operátor, elég ha az egyik oldal igaz, hogy az eredmény igaz legyen

            // numerikus változók növelése, csökkentése
            var szam = 5;
            var pluszEgy = szam + 1;
            szam += 10; // szam = szam + 10;
            szam--; // szam = szam - 1;


            // Fogadd el hogy ez ilyen
            Console.WriteLine("Kiiratás és új sor");
            Console.Write("Csak kiiratás");
            //var input = Console.ReadLine(); // Beolvasás CSAK SZÖVEGES
            //var numerikusInput = Convert.ToInt32(input); // Beolvasott szöveges érték átalakítása numerikus típusr
        }
    }
}
