using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class Star : VisualObject
    {
        //  Создаем конструктор. Данные надо передать в конструктор базового класса :base(Position, Direction, new Size(Size, Size))
        public Star(Point Position, Point Direction, int Size) :base(Position, Direction, new Size(Size, Size))
        {

        }
    }
}
