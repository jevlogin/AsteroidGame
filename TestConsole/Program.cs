using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Loggers;

/*
 * Классы - это ссылочный тип данных.
 * Структуры - это значимый тип данных.
 *  abstract - если коротко, наложение ограничений на создание объектов этого класса
 * 
 */
namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Logger logger = new ListLogger();
            //Logger logger = new FileLogger("programm_log.txt");
            //Logger logger = new VisualStudioOutputLogger();
            Logger logger = new TraceLogger();
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

            ListLogger critical_logger = new ListLogger();
            var student_logger = new Student { Name = "Ivanov" };
            DoSomeCriticalWork(critical_logger);

            logger.LogInformation("Start programm\n");

            for (int i = 0; i < 10; i++)
            {
                logger.LogInformation($"Do some work {i + 1}\n");
            }

            logger.LogWarning("Завершение работы\n");

            Trace.Flush();

            //var log_messages = ((ListLogger)logger).Messages;

            Console.ReadKey();
        }

        public static void DoSomeCriticalWork(Logger log)
        {
            for (int i = 0; i < 10; i++)
            {
                log.LogInformation($"Do some very important work {i + 1} {log}");
            }
        }
    }

    public class Student : ILogger
    {
        private List<string> _Messages = new List<string>();
        public string Name { get; set; }

        public List<int> Rating { get; set; } = new List<int>();

        public void Log(string Message)
        {
            Rating.Add(Message.Length);
            _Messages.Add(Message);
        }

        public void LogError(string Message)
        {
            Log($"Error: {Message}");
        }

        public void LogInformation(string Message)
        {
            Log($"Info: {Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"Warning: {Message}");
        }
    }
}
