﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    class Asteroid : ImageObject, ICollision
    {
        static Random rnd = new Random();
        public int Power { get; set; } = rnd.Next(1, 6); //  Мощность астероида от 1 до 5

        public Asteroid(Point Position, Point Direction, int ImageSize) : base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.asteroid)
        {

        }

        //public Rectangle Rect => throw new NotImplementedException();

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }
    }
}
