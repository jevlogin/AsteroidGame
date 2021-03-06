﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public Point Position => _Position;

        public Rectangle Rect => new Rectangle(_Position, _Size);

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);  //  Этот метод должен быть у всех наследников

        public virtual void Update()
        {
            _Position = new Point(_Position.X + _Direction.X, _Position.Y + _Direction.Y);

            if (_Position.X < 0)
            {
                _Direction = new Point(-_Direction.X, _Direction.Y);
            }
            if (_Position.Y < 0)
            {
                _Direction = new Point(_Direction.X, -_Direction.Y);
            }
            if (_Position.X > Game.Width)
            {
                _Direction = new Point(-_Direction.X, _Direction.Y);
            }
            if (_Position.Y > Game.Width)
            {
                _Direction = new Point(_Direction.X, -_Direction.Y);
            }
        }
    }
}
