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
        private Vector2D _Position = new Vector2D(5, 7);

        //  Отличный комментарий: "Давайте сделаем Вектор 2Д"
        public Vector2D Position { get => _Position; set => _Position = value; }


        //  Конструктор по умолчанию
        public SpaceShip()
        {

        }
        //  Конструктор параметрический
        public SpaceShip(Vector2D Position)
        {
            _Position = Position;
        }
    }

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
