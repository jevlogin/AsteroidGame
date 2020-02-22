using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer("JEVLOGIN", new DateTime(1987, 1, 24, 0, 0, 0));

            Gamer[] gamers = new Gamer[100];
            for (int i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer($"Gamer {i + 1}", DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));
                gamers[i] = g;
            }

            gamer.SayYourName();

            foreach (var g in gamers)
            {
                g.SayYourName();
            }

            //gamer.SetName("Максим");
            //Console.WriteLine($"{gamer.GetName()}");

            gamer.Name = "Konstantin";

            //gamer.GetNameLength();

            Console.WriteLine($"Игрок первый = {gamer.Name}");

            Console.ReadKey();
        }
    }
}
