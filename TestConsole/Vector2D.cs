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

        //  Оператор сложения векторов. Все намного проще, чем казалось на первый взгляд.
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }
        //  Оператор разности векторов. Множественный курсор shift + alt + >, shift + alt + <
        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }
        //  Оператор сложения векторов и числа. 
        public static Vector2D operator +(Vector2D a, double value)
        {
            return new Vector2D(a.X + value, a.Y + value);
        }

        public static Vector2D operator -(Vector2D a)
        {
            return new Vector2D(-a.X, -a.Y);
        }

    }
}
