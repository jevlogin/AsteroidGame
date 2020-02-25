using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Bullet : CollisionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        public Bullet(int Position) : base(new Point(0, Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY))
        {

        }

        public Rectangle Rect => throw new NotImplementedException();

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.LightPink, new Rectangle(_Position, _Size));
            g.DrawEllipse(Pens.Silver, new Rectangle(_Position, _Size));
            g.FillRectangle(Brushes.Yellow, new RectangleF(_Position, new Size(_Size.Width - 10, _Size.Height)));
            g.DrawRectangle(Pens.LightGoldenrodYellow, new Rectangle(_Position, new Size(_Size.Width - 10, _Size.Height)));
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + 3, _Position.Y);

        }
    }
}
