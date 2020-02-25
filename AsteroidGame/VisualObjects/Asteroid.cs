using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects;

namespace AsteroidGame.VisualObjects
{
    class Asteroid : ImageObject
    {
        public Asteroid(Point Position, Point Direction, int ImageSize) :base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.asteroid)
        {

        }
    }
}
