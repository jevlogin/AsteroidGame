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
            #region Введение
            //Gamer gamer = new Gamer("JEVLOGIN", new DateTime(1987, 1, 24, 0, 0, 0));

            //Gamer[] gamers = new Gamer[100];
            //for (int i = 0; i < gamers.Length; i++)
            //{
            //    var g = new Gamer($"Gamer {i + 1}", DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));
            //    gamers[i] = g;
            //}

            //gamer.SayYourName();

            //foreach (var g in gamers)
            //{
            //    g.SayYourName();
            //}


            ////gamer.SetName("Максим");
            ////Console.WriteLine($"{gamer.GetName()}");

            //gamer.Name = "Konstantin";

            ////gamer.GetNameLength();

            //Console.WriteLine($"Игрок первый = {gamer.Name}");

            #endregion

            #region test space_ship and vector

            //var space_ship = new SpaceShip(new Vector2D(5, 7));
            //var space_ship2 = space_ship;
            //space_ship.Position = new Vector2D(150, -210);

            //var v1 = new Vector2D(1, 8);
            //var v2 = v1;
            //v1.X = 7;
            //v1.Y = -14;

            #endregion

            #region Operator+, Operator-

            //var v1 = new Vector2D(1, 8);
            //var v2 = v1;
            //v1.X = 7;
            //v1.Y = -14;

            //var v3 = v1 + v2;
            //var v4 = v2 - v1;

            //var v5 = v4 + 7;

            //var v6 = -v5;

            #endregion

            #region Printer

            Printer printer = new Printer();

            printer.Print("Привет Мир!");

            printer = new PrefixPrinter(">>>>>>> ");

            printer.Print("Привет Мир!");

            printer = new DateTimeLogPrinter();

            printer.Print("Привет Мир!");

            printer = new FilePrinter("test.txt");
            printer.Print("Ну здравствуй Питер.");


            #endregion
            Console.ReadKey();
        }
    }

    class Printer
    {
        //  Пустой конструктор
        public Printer()
        {

        }
        public virtual void Print(string str)
        {
            Console.WriteLine(str);
        }
    }

    class PrefixPrinter : Printer
    {
        private string _Prefix;

        //  Учимся использовать ЛЯМБДА ВЫРАЖЕНИЯ
        public PrefixPrinter(string Prefix) => _Prefix = Prefix;

        //  Переопределили ВИРТУАЛЬНЫЙ МЕТОД
        public override void Print(string str)
        {
            //Console.WriteLine($"{_Prefix}{str}");
            //  использовали метод базового класса.
            base.Print(_Prefix + str);
        }
    }

    class DateTimeLogPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.Write(DateTime.Now);
            Console.Write(" >> ");
            base.Print(str);
        }
    }

    class FilePrinter : Printer
    {
        private string _FileName;

        public FilePrinter(string FileName) => _FileName = FileName;

        public override void Print(string str)
        {
            System.IO.File.AppendAllText(_FileName, str);
        }
    }
}
