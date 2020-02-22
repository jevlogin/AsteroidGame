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
            Console.WriteLine($"Игрок первый = {gamer.Name}");

            Console.ReadKey();
        }
    }

    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;


        //  Это свойство.
        public string Name
        {
            get
            {
                //return _Name ?? string.Empty                  //  А это не тернарный оператор )))
                //return _Name == null ? string.Empty : _Name;  //  Тернарный оператор
                
                //  А это через стандартный if else
                if (_Name == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _Name;
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _Name = value;
            }
        }

        public Gamer(string Name, DateTime DayOfBirth)
        {
            _Name = Name;
            _DayOfBirth = DayOfBirth;

        }

        //public void SetName(string value)
        //{
        //    _Name = value;
        //}
        //public string GetName()
        //{
        //    return _Name;
        //}


        public void SayYourName()
        {
            Console.WriteLine($"{_Name} {_DayOfBirth:dd:MM:yyyy HH:mm:ss}");
        }
    }
}
