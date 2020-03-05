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
         */
        private const int __FrameTimeout = 10;
        //  Статический класс способен хранить внутри себя только статические методы. Экземпляр этого класса создать нельзя.

        //  Графический контекст и буфер, новые звери в моем понимании
        //  обычная переменная с одним подчеркиванием, статические с двумя
        private static BufferedGraphicsContext __Context;

        public static Graphics Graphics { get; private set; }

        private static BufferedGraphics __Buffer;

        private static Timer __Timer;

        public static Action<string> Log { get; set; }

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

            /*
            Log("Выполнена Инициализация.");    
                Можно было бы и так написать. 
                Но внутри метода может быть пустая ссылка. 
                Тем самым мы защищаем себя вызовом метода Invoke()
            */
            Log?.Invoke("Выполнена Инициализация.");
        }

        private static int __KeyPressedF1;
        private static int __KeyPressedCtrl;
        private static int __KeyPressedUp;
        private static int __KeyPressedDown;
        private static int __KeyPressedLeft;
        private static int __KeyPressedRight;
        private static void OnFormKeyDown(object Sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    __KeyPressedCtrl++;
                    break;
                case Keys.Up:
                    __KeyPressedUp++;
                    break;
                case Keys.Down:
                    __KeyPressedDown++;
                    break;
                case Keys.Right:
                    __KeyPressedRight++;
                    break;
                case Keys.Left:
                    __KeyPressedLeft++;
                    break;
                case Keys.F1:
                    __KeyPressedF1++;
                    break;
            }
            Log?.Invoke($"Нажата кнопка {E.KeyCode}");

        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static SpaceShip __Ship;
        private static VisualObject[] __GameObjects;
        private static List<VisualObject> __AsteroidList;
        public static Random rnd = new Random();
        //TODO что-то пока не получается создать коллекцию

        //private static Bullet __Bullet;
        private static List<Bullet> __Bullets = new List<Bullet>(); // создали список пуль

        public static void Load()
        {
            Log?.Invoke($"Загрузка данных сцены...");

            var game_objects = new List<VisualObject>();
            __AsteroidList = new List<VisualObject>();


            const int star_count = 100;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (int i = 0; i < star_count; i++)
            {
                game_objects.Add(new Star(new Point(rnd.Next(0, Width),
                    rnd.Next(0, Height)), new Point(rnd.Next(0, star_max_speed), 0),
                    star_size));
            }
            Log?.Invoke($"Созданы звезды. Количество {star_count}");

            AsteroidListCreate(__AsteroidList, rnd);
            Log?.Invoke($"{Level.NameLevelGame}\nАстероидов создано {__AsteroidList.Count}\n");


            __GameObjects = game_objects.ToArray();
            __AsteroidList = __AsteroidList.ToList();

            __Ship = new SpaceShip(new Point(10, 300), new Point(5, 5), 40);
            __Ship.ShipDestroyed += OnShipDestroyed;

            Log?.Invoke($"Загрузка данных сцены выполнена успешно.");

        }

        private static void AsteroidListCreate(List<VisualObject> game_asteroids, Random rnd)
        {
            int asteroids_count = 5 * Level.LevelGame;
            const int asteroid_size = 30;
            const int asteroid_max_speed = 20;
            if (Level.LevelGame < 3)
            {
                for (int i = 0; i <= asteroids_count; i++)
                {
                    //game_asteroids.Add(new Asteroid(new Point(rnd.Next(0, Width),
                    //    rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                    //    asteroid_size));
                    game_asteroids.Add(new Asteroid(new Point(rnd.Next(0, Width),
                        rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                        asteroid_size, $"Астероид {Level.LevelGame}-{game_asteroids.Count()}-"));
                }
            }
            else
            {
                Asteroid.Power = rnd.Next(5, 20);
                for (int i = 0; i <= asteroids_count; i++)
                {
                    game_asteroids.Add(new Asteroid(new Point(rnd.Next(0, Width),
                        rnd.Next(0, Height)), new Point(rnd.Next(0, asteroid_max_speed), rnd.Next(0, 10)),
                        asteroid_size, $"Астероид {Level.LevelGame}-{game_asteroids.Count()}-"));
                }
            }
            
        }


        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            __Buffer.Graphics.Clear(Color.DarkBlue);
            if (Level.LevelGame < 5)
            {
                __Buffer.Graphics.Clear(Color.Red);
                __Buffer.Graphics.DrawString("Game Over!\nYou\nFucking\nLooser!", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Yellow, 100, 100);
            }
            else
            {
                __Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            }
            __Buffer.Render();

            Log?.Invoke($"Корабль уничтожен.");
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

            foreach (var bullet in __Bullets)
            {
                bullet.Draw(g);
            }

            __Ship.Draw(g);
            var score_ship = $"Score: {__Ship.Score}";

            g.DrawString($"Energy: {__Ship.Energy}", new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.Green, 10, 10);
            g.DrawString(score_ship, new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.Yellow, Game.Width - score_ship.Length * 20, 10);
            g.DrawString(Level.NameLevelGame, new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.Red, (Game.Width / 2 - Level.NameLevelGame.Length * 5), 10);
            g.DrawString($"Press F1 to BUY Energy Ship\n 1000 очков - 50ХП", new Font(FontFamily.GenericSansSerif, 8), Brushes.LightPink, Width - 200, Height - 100);

            __Buffer.Render();
        }

        //  обновление для всех объектов через класс Game
        public static void Update()
        {
            if (__KeyPressedCtrl > 0)
            {
                for (int i = 0; i < __KeyPressedCtrl; i++)
                {
                    __Bullets.Add(new Bullet(__Ship.Position.X + 30, __Ship.Position.Y + 10));
                }
                __KeyPressedCtrl = 0;
            }
            if (__KeyPressedUp > 0)
            {
                for (int i = 0; i < __KeyPressedUp; i++)
                {
                    __Ship.MoveUp();
                }
                __KeyPressedUp = 0;
            }
            if (__KeyPressedDown > 0)
            {
                for (int i = 0; i < __KeyPressedDown; i++)
                {
                    __Ship.MoveDown();
                }
                __KeyPressedDown = 0;
            }
            if (__KeyPressedLeft > 0)
            {
                for (int i = 0; i < __KeyPressedLeft; i++)
                {
                    __Ship.MoveLeft();
                }
                __KeyPressedLeft = 0;
            }
            if (__KeyPressedRight > 0)
            {
                for (int i = 0; i < __KeyPressedRight; i++)
                {
                    __Ship.MoveRight();
                }
                __KeyPressedRight = 0;
            }
            if (__KeyPressedF1 > 0)
            {
                if (__Ship.Score >= 1000)
                {
                    __Ship.Score -= 1000;
                    __Ship.Energy += 50;
                }
                __KeyPressedF1 = 0;
            }
            foreach (var visual_object in __GameObjects)
            {
                visual_object?.Update();
            }
            foreach (var asteroid in __AsteroidList)
            {
                asteroid?.Update();
            }
            if (__AsteroidList.Count <= 0)
            {
                //TODO При убийстве всех астероидов будет прибавляться 1000 очков и 100 ХП
                __Ship.Score += 300;
                __Ship.Energy += 30;
                Level.LevelGame++;
                AsteroidListCreate(__AsteroidList, rnd);
            }

            var bullets_to_remove = new List<Bullet>();
            var asteroids_to_remove = new List<Asteroid>(); // добавили список на удаление астероидов

            foreach (var bullet in __Bullets)
            {
                bullet.Update();
                if (bullet.Position.X > Width)
                {
                    bullets_to_remove.Add(bullet);
                }
            }

            for (int i = 0; i < __AsteroidList.Count; i++)
            {
                var obj = __AsteroidList[i];
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

                            asteroids_to_remove.Add((Asteroid)collision_object);    //TODO И что мне делать двойное кастование?
                            //TODO при попадании выстрелом в астероид будут начисляться очки
                            __Ship.Score += 100;

                        }
                    }

                    //TODO  Пока такой способ, при столкновении корабля с астероидами, астероид уничтожается, корабль повреждается
                    if (__Ship != null && __Ship.CheckCollision(collision_object))
                    {
                        //TODO  При столкновении с кораблем астероид взрывается
                        //__AsteroidList.Remove(obj);
                        asteroids_to_remove.Add((Asteroid)collision_object);    //TODO И что мне делать двойное кастование?
                        //TODO При столкновении корабля с астероидами отнимаются не только жизни, но и очки
                        __Ship.Score -= 50;
                    }
                }
            }

            foreach (var asteroid in asteroids_to_remove)
            {
                __AsteroidList.Remove(asteroid);   // удалил астероиды вне цикла итерации выше.
                Log?.Invoke($"Астероид {asteroid} уничтожен");

            }

            //  Метод удаления и использованием linq мне не понравился, так как там не исчезали пули.
            foreach (var bullet in bullets_to_remove)
            {
                __Bullets.Remove(bullet);
            }
        }
    }
}
