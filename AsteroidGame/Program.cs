﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Game.Log += log_str => Debug.WriteLine($">>>>> {log_str}");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form();
            form.Width = 800;
            form.Height = 600;

            form.Show();
            //  инициализировали метод Initialize() и передали форму.
            Game.Initialize(form);
            Game.Load();
            Game.Draw();

            Application.Run(form);
        }
    }
}
