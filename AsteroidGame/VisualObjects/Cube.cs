using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Cube : VisualObject
    {
        public Cube(Point Position, Point Direction, int Size) :base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Red, new Rectangle(_Position.X, _Position.Y, _Direction.X, _Direction.Y));

        }

        public override void Update()
        {
            _Position.X -= _Direction.X;
            if (_Position.X < 0)
            {
                _Position.X = Game.Width + _Size.Width;
            }
            _Position.Y -= _Direction.Y;
            if (_Position.Y < 0)
            {
                _Position.Y = Game.Width + _Size.Width;
            }
            
        }
    }
}
