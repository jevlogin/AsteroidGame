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
        }
    }
}
