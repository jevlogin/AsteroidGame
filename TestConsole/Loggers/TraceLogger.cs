﻿/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
using System;
using System.Diagnostics;

namespace TestConsole
{
    public class TraceLogger : DebugLogger, IDisposable
    {
        public void Dispose()
        {
            Trace.Flush();
        }

        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>> {Message}, {Category}");

        }
        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>> {Message}");
        }
    }

}

