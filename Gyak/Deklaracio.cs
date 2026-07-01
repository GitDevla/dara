using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak
{
    internal class Deklaracio
    {
        public static void Dara()
        {
            // Változók & értékadás
            string szoveges = "John Doe"; // string = szöveges típus
            int numerikus = 30; // int = egész szám típus
            bool igazHamis = false; // bool = logikai típus (igaz/hamis)

            var varazsMegadas = "Ki találja a típust?"; // Var típusú változó, a fordító automatikusan meghatározza a típust az érték alapján

            // Syntaxis: tipus nevés = értéket;

            // Fogadd el hogy ez ilyen
            Console.WriteLine("Kiiratás és új sor"); // konzolra kiiratás és új sor
            Console.Write("Csak kiiratás"); // konzolra kiiratás, de nem új sor
            var input = Console.ReadLine(); // Beolvasás CSAK SZÖVEGES
            var numerikusInput = Convert.ToInt32(input); // Beolvasott szöveges érték átalakítása numerikus típusra

            // Példa:
            Console.Write("Kérlek add meg az életkorod: ");
            var eletkorString = Console.ReadLine();
            var eletkor = Convert.ToInt32(eletkorString);
            Console.WriteLine("Az életkorod: " + eletkor);
        }
    }
}
