/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */

namespace TestConsole.Loggers
{
    public abstract class Logger : ILogger
    {
        public abstract void Log(string Message);   //  абстрактный метод

        public void LogInformation(string Message)
        {
            Log($"[Info]:{Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"[Warning]:{Message}");
        }

        public void LogError(string Message)
        {
            Log($"[Error]:{Message}");
        }
    }
}

