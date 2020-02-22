using System;

namespace TestConsole
{
    struct Vector2D
    {
        private double _X;
        //  писать поле не обязательно, так как использовали автосвойство.
        //private double _Y;

        //  Простое свойство.
        public double X { get { return _X; } set { _X = value; } }
        //  Ниже лямбда выражение
        //public double Y { get => _Y; set => _Y = value; }
        //  А внизу автосвойство. Свойство для ленивых
        public double Y { get; set; }

        public double Length => Math.Sqrt(X * X + Y * Y);

        //  У структур нет конструктора по умолчанию.
        public Vector2D(double X, double Y)
        {
            _X = X;
            this.Y = Y; //  потому что использовали автосвойство
        }

    }
}
