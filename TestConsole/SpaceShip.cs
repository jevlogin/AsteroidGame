using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class SpaceShip
    {
        //  Класс это полнофункциаональный тип данных. Хранится в куче. Ссылочный.

    }

    struct Vector2D
    {
        private double _X;
        private double _Y;

        //  Простое свойство.
        public double X { get { return _X; } set { _X = value; } }
        //  Ниже лямбда выражение
        public double Y { get => _Y; set => _Y = value; }
        //  А внизу автосвойство. Свойство для ленивых
        //public double Y { get; set; }

    }
}
