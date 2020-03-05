using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Bullet : ImageObject, ICollision
    {
        //  Если я правильно поянл, это размеры снаряда
        private const int __BulletSizeX = 30;
        private const int __BulletSizeY = 10;
        private int v;

        public Bullet(int Position) : base(new Point(0, Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY), Properties.Resources.Bullet1)
        {
        }

        public Bullet(int PositionX, int PositionY) : base(new Point(PositionX, PositionY), Point.Empty, new Size(__BulletSizeX, __BulletSizeY), Properties.Resources.Bullet1)
        {
        }

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + 20, _Position.Y);   //  увеличивая константу, можно ускорить полет пули

        }
    }
}
