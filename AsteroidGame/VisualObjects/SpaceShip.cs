using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : ImageObject, ICollision
    {
        public event EventHandler ShipDestroyed;

        public int Score { get; set; } = 0;
        public int Energy { get; set; } = 100;

        public SpaceShip(Point Position, Point Direction, int ImageSize) : base(Position, Direction, new Size(ImageSize * 2, ImageSize), Properties.Resources.SpaceShip1)
        {
        }

        public override void Update()
        {
        }
        public void ChangeScore(int Score)
        {
            Score += Score;
        }
        public void ChangeEnergy(int Delta)
        {
            Energy += Delta;
            if (Energy < 0)
            {
                ShipDestroyed?.Invoke(this, EventArgs.Empty);
            }
        }

        public void MoveUp()
        {
            if (_Position.Y > 0)
            {
                _Position = new Point(_Position.X, _Position.Y - _Direction.Y);
            }

        }

        public void MoveDown(int Offset = 1)
        {
            if (_Position.Y - _Size.Height < Game.Height)
            {
                _Position = new Point(_Position.X, _Position.Y + _Direction.Y);
            }
        }
        public void MoveRight()
        {
            if (_Position.X - _Size.Width < Game.Width)
            {
                _Position = new Point(_Position.X + _Direction.X, _Position.Y);
            }
        }
        public void MoveLeft()
        {
            if (_Position.X > 0)
            {
                _Position = new Point(_Position.X - _Direction.X, _Position.Y);
            }
        }

        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);
            if (is_collision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }
            return is_collision;
        }

    }
}
