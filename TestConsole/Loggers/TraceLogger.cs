/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
namespace TestConsole
{
    public class TraceLogger : DebugLogger
    {
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

