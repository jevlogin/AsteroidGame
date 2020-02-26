using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public abstract class CollisionObject : VisualObject, ICollision
    {
        public CollisionObject(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
        }

        public bool CheckCollision(ICollision other)
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
