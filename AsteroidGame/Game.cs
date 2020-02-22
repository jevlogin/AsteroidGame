using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
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

            var timer = new Timer { Interval = 50 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        public static void Load()
        {
            __GameObjects = new VisualObject[30];
            for (int i = 0; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new VisualObject(new Point(600, i * 20), new Point(15 - i, 20 - i), new Size(20, 20));
            }
        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var visual_object in __GameObjects)
            {
                visual_object.Draw(g);
            }

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
            {
                visual_object.Update();
            }
        }
    }
}
