/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
using TestConsole.Loggers;

namespace TestConsole
{
    public abstract class DebugLogger : Logger
    {
        public abstract void Log(string Messages, string Category);
    }

}

