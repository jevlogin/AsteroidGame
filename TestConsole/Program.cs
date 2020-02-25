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
    }


}
