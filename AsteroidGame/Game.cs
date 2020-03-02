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
         */
        private const int __FrameTimeout = 10;
        //  Статический класс способен хранить внутри себя только статические методы. Экземпляр этого класса создать нельзя.

        //  Графический контекст и буфер, новые звери в моем понимании
        //  обычная переменная с одним подчеркиванием, статические с двумя
        private static BufferedGraphicsContext __Context;

        public static Graphics Graphics { get; private set; }

        private static BufferedGraphics __Buffer;

        private static Timer __Timer;

        public static int Width { get; set; }
        public static int Height { get; set; }

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
            __Timer = timer;

            form.KeyDown += OnFormKeyDown;
        }

        private static void OnFormKeyDown(object Sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullets.Add(new Bullet(__Ship.Position.X + 30, __Ship.Position.Y + 10)); 
                    // добавили пулю посиция относительно корабля координаты __Ship.Position.X __Ship.Position.Y
                    //TODO  Корректировать положение пули будем тут
                    break;
                case Keys.Up:
                    __Ship.MoveUp();
                    break;
                case Keys.Down:
                    __Ship.MoveDown();
                    break;
                case Keys.Right:
                    __Ship.MoveRight(); //  не забыть дописать методы
                    break;
                case Keys.Left:
                    __Ship.MoveLeft();  //  не забыть дописать методы
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
        private static List<VisualObject> __AsteroidList;
        //TODO что-то пока не получается создать коллекцию

        //private static Bullet __Bullet;
        private static List<Bullet> __Bullets = new List<Bullet>(); // создали список пуль

        public static void Load()
        {
            var game_objects = new List<VisualObject>();
            var game_asteroids = new List<VisualObject>();
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


            const int asteroids_count = 20;
            const int asteroid_size = 30;
            const int asteroid_max_speed = 20;
            for (int i = 0; i < asteroids_count; i++)
            {
                game_asteroids.Add(new Asteroid(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                    asteroid_size));
            }

            __GameObjects = game_objects.ToArray();
            __AsteroidList = game_asteroids.ToList();

            __Ship = new SpaceShip(new Point(10, 300), new Point(5, 5), 40);
            __Ship.ShipDestroyed += OnShipDestroyed;
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            __Buffer.Graphics.Clear(Color.DarkBlue);
            __Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Buffer.Render();
        }

        public static void Draw()
        {
            if (__Ship.Energy <= 0)
            {
                return;
            }
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Draw(g);
            }
            foreach (var asteroid in __AsteroidList)
            {
                asteroid?.Draw(g);
            }

            //__Bullet?.Draw(g);

            foreach (var bullet in __Bullets)
            {
                bullet.Draw(g); //TODO - ЧТО ТАКОЕ g?? нужно объяснение прямо как для тупых ))
            }

            __Ship.Draw(g);
            var score_ship = $"Score: {__Ship.Score}";

            g.DrawString($"Energy: {__Ship.Energy}", new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.Green, 10, 10);
            g.DrawString(score_ship, new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.Yellow, Game.Width - score_ship.Length*20, 10);

            __Buffer.Render();
        }

        //  обновление для всех объектов через класс Game
        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Update();
            }
            foreach (var asteroid in __AsteroidList)
            {
                asteroid?.Update();
            }


            var bullets_to_remove = new List<Bullet>();
            foreach (var bullet in __Bullets)
            {
                bullet.Update();
                if (bullet.Position.X > Width)
                {
                    bullets_to_remove.Add(bullet);
                }
            }
            //__Bullet?.Update();

            for (int i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    __Ship.CheckCollision(collision_object);

                    foreach (var bullet in __Bullets.ToArray())
                    {
                        if (bullet.CheckCollision(collision_object))
                        {
                            //  сперва добавляем все элементы которые хотим удалить в промежуточный список,
                            //  а уже затем удаляем список в другом цикле
                            bullets_to_remove.Add(bullet);
                            __GameObjects[i] = null;
                            //MessageBox.Show($"Астероид уничтожен!", "Столкновение", MessageBoxButtons.OK); //TODO оповещение о столкновении пули с астероидом
                        }
                    }

                    //TODO  Пока такой способ, при столкновении корабля с астероидами, астероид уничтожается, корабль повреждается
                    if (__Ship != null && __Ship.CheckCollision(collision_object))
                    {
                        //TODO  В будущем переделать, чтобы астероид разбивался на 2 части в зависимости от мощности.
                        __GameObjects[i] = null;
                    }
                }
            }

            //  Метод удаления и использованием linq мне не понравился, так как там не исчезали пули.
            foreach (var bullet in bullets_to_remove)
            {
                __Bullets.Remove(bullet);
            }
        }
    }
}
