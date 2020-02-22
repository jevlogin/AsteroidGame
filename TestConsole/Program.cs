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
            Gamer gamer = new Gamer();
            gamer.Name = "JEVLOGIN";
            gamer.DayOfBirth = new DateTime(1987, 1, 24, 0, 0, 0);

            Gamer[] gamers = new Gamer[100];
            for (int i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer();
                g.Name = $"Gamer {i + 1}";
                g.DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18)));
                gamers[i] = g;
            }

            gamer.SayYourName();

            foreach (var g in gamers)
            {
                g.SayYourName();
            }


            Console.ReadKey();
        }
    }

    class Gamer
    {
        public string Name;
        public DateTime DayOfBirth;

        public void SayYourName()
        {
            Console.WriteLine($"{Name} {DayOfBirth:dd:MM:yyyy HH:mm:ss}");
        }
    }
}
