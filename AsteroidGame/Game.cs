using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame
{
    static class Game
    {
        /*
         * Установили таймаут в 10 мс
         * 
         */
        private const int __FrameTimeout = 10;
        //  Статический класс способен хранить внутри себя только статические методы. Экземпляр этого класса создать нельзя.

        //  Графический контекст и буфер, новые звери в моем понимании
        //  обычная переменная с одним подчеркиванием, статические с двумя
        private static BufferedGraphicsContext __Context;

        public static Graphics Graphics { get; private set; }

        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        //  Статический конструктор  вызывается в непрогнозируемое время
        //static Game()
        //{

        //}

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();

            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            //  Создаем таймер
            var timer = new Timer { Interval = __FrameTimeout };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        public static void Load()
        {
            var game_objects = new List<VisualObject>();
            var rnd = new Random();

            const int star_count = 100;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (int i = 0; i < star_count; i++)
            {
                game_objects.Add(new Star(new Point(rnd.Next(0, Width), 
                    rnd.Next(0, Height)), new Point(rnd.Next(0, star_max_speed), 0), 
                    star_size));
            }

            const int ellipse_count = 20;
            const int ellipse_size_x = 20;
            const int ellipse_size_y = 30;
            for (int i = 0; i < ellipse_count; i++)
            {
                game_objects.Add(new EllipseObject(new Point(600, i * 20), 
                    new Point(15 - i, 20 - i), 
                    new Size(ellipse_size_x, ellipse_size_y)));
            }

            const int asteroids_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (int i = 0; i < asteroids_count; i++)
            {
                game_objects.Add(new Asteroid(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                    asteroid_size));
            }



            #region Это нам не нравится ))
            //__GameObjects = new VisualObject[30];
            //for (int i = 0; i < __GameObjects.Length / 3; i++)
            //{
            //    //__GameObjects[i] = new VisualObject(new Point(600, i * 20), new Point(15 - i, 20 - i), new Size(20, 20));
            //}

            //for (int i = __GameObjects.Length / 3; i < __GameObjects.Length *2 / 3; i++)
            //{
            //    __GameObjects[i] = new Star(new Point(600, i * 10), new Point(i, 20 - i), 20);
            //}

            //for (int i = __GameObjects.Length * 2 / 3; i < __GameObjects.Length; i++)
            //{
            //    __GameObjects[i] = new Cube(new Point(600, i * 10), new Point(i, 20), 20);
            //}
            #endregion

            //var image = Properties.Resources.asteroid;
            //var image_object = new ImageObject(new Point(4, 7), new Point(7, 7), new Size(20, 20), image);

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);

        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Draw(g);
            }

            __Bullet.Draw(g);

            __Buffer.Render();
        }

        //  обновление для всех объектов через класс Game
        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Update();
            }
            __Bullet.Update();
            if (__Bullet.Position.X > Width)
            {
                __Bullet = new Bullet(new Random().Next(Width));
            }
            for (int i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (__Bullet.CheckCollision(collision_object))
                    {
                        __Bullet = new Bullet(new Random().Next(Height));
                        __GameObjects[i] = null;
                        MessageBox.Show($"Астероид уничтожен!", "Столкновение", MessageBoxButtons.OK); //   Изменение оповещения
                    }
                }
            }
        }
    }
}
