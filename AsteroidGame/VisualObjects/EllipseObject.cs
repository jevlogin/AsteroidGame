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
            g.DrawEllipse(Pens.Red, Rect);
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
