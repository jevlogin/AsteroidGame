﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class EllipseObject : VisualObject
    {
        public EllipseObject(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {

        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Red, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }
        public override void Update()
        {
            base.Update();
        }
    }
}