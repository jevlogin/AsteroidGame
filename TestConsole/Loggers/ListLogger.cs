/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
using System;
using System.Collections.Generic;
using TestConsole.Loggers;

namespace TestConsole
{
    public class ListLogger : Logger
    {
        private readonly List<string> _Messages = new List<string>();

        public string[] Messages => _Messages.ToArray();

        //public string[] Messages
        //{
        //    get
        //    {
        //        return _Messages.ToArray();
        //    }
        //}

        public override void Log(string Message)
        {
            _Messages.Add($"({DateTime.Now}){Message}");
        }
    }

}

