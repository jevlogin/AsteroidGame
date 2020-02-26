/*
 * Интерфейс
 * 
 */

namespace TestConsole.Loggers
{
    interface ILogger
    {
        //  Вот так записываются интерфейсы
        void Log(string Message);

        void LogInformation(string Message);

        void LogWarning(string Message);

        void LogError(string Message);
    }
}

