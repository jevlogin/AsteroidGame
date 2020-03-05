/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
using TestConsole.Loggers;

namespace TestConsole
{
    public class FileLogger : Logger
    {
        private int _Index;
        public string FilePath { get; } 
        public FileLogger(string FilePath)
        {
            this.FilePath = FilePath;
        }

        public override void Log(string Message)
        {
            System.IO.File.AppendAllText(FilePath, $"{++_Index}:{Message}");
        }

    }

}

