﻿using System;
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
        private const int __FrameTimeout = 30;
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

            form.KeyDown += OnFormKeyDown;
        }

        private static void OnFormKeyDown(object Sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullet = new Bullet(__Ship.Position.Y);
                    break;
                case Keys.Up:
                    __Ship.MoveUp();
                    break;
                case Keys.Down:
                    __Ship.MoveDown();
                    break;
            }
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static SpaceShip __Ship;

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

           
            const int asteroids_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (int i = 0; i < asteroids_count; i++)
            {
                game_objects.Add(new Asteroid(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                    asteroid_size));
            }


            __GameObjects = game_objects.ToArray();
            //__Bullet = new Bullet(200);
            //__Bullet = new Bullet(Game.Height);   //  первая пуля будет за предделами поля по высоте окна игры
            //__Bullet = null;  //  или просто не рисуем первую пулю. Только когда полетит после выстрела
            __Ship = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(10, 10));
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

            __Bullet?.Draw(g);
            __Ship.Draw(g);

            __Buffer.Render();
        }

        //  обновление для всех объектов через класс Game
        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Update();
            }

            __Bullet?.Update();
            for (int i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (__Bullet != null && __Bullet.CheckCollision(collision_object))
                    {
                        __Bullet = null;
                        //__Bullet = new Bullet(new Random().Next(Height));
                        __GameObjects[i] = null;
                        //MessageBox.Show($"Астероид уничтожен!", "Столкновение", MessageBoxButtons.OK); //   Изменение оповещения
                    }
                }
            }
        }
    }
}
