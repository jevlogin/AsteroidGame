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
            //  Эта конструкция может быть упрощена.
            //TraceLogger trace_logger = null;
            //try
            //{
            //    trace_logger = new TraceLogger();
            //    trace_logger.Log("123");
            //}
            //finally
            //{
            //    trace_logger.Dispose();
            //}

            using (var trace_logger = new TraceLogger())
            {
                //  Если мы будем работать с объектами для чтения или записи файлов
                //  Сетью и еще рядом других подобных вещей, то обязательно оборачивать их в конструкцию using
                trace_logger.Log("123");
            }

            //Logger logger = new ListLogger();
            //Logger logger = new FileLogger("programm_log.txt");
            //Logger logger = new VisualStudioOutputLogger();
            Logger logger = new TraceLogger();
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

            ListLogger critical_logger = new ListLogger();
            var student_logger = new Student { Name = "Ivanov" };

            //  Интерфейс скрыт от пользователя.
            //student_logger.LogError("Do some work");
            //  Чтобы использовать этот метод, необходимо явно привести к интерфейсу.
            ((ILogger)student_logger).LogError("Do some work");

            DoSomeCriticalWork(student_logger);

            logger.LogInformation("Start programm\n");

            for (int i = 0; i < 10; i++)
            {
                logger.LogInformation($"Do some work {i + 1}\n");
            }

            logger.LogWarning("Завершение работы\n");

            //var log_messages = ((ListLogger)logger).Messages;

            var rnd = new Random();
            var students = new Student[100];
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student {Name = $"{i + 1}", Height = rnd.Next(150, 211) };
            }
            Array.Sort(students);

            Trace.Flush();
            Console.ReadKey();
        }

        public static void DoSomeCriticalWork(ILogger log)
        {
            for (int i = 0; i < 10; i++)
            {
                log.LogInformation($"Do some very important work {i + 1} {log}");
            }
        }
    }

    public class Student : ILogger, IComparable
    {
        private List<string> _Messages = new List<string>();
        public string Name { get; set; }
        public double Height { get; set; } = 174;

        public List<int> Rating { get; set; } = new List<int>();

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                var other_student = (Student)obj;
                //return StringComparer.OrdinalIgnoreCase.Compare(Name, other_student.Name);
                if (Height > other_student.Height)
                {
                    return +1;
                }
                else if (Height.Equals(other_student.Height))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), $"Попытка сравнения студента с пустотой");
            }
            else
            {
                throw new ArgumentException($"Попытка сравнения студента с {obj.GetType().Name}", nameof(obj));
            }
        }

        public void Log(string Message)
        {
            Rating.Add(Message.Length);
            _Messages.Add(Message);
        }

        //public void LogError(string Message)
        //{
        //    Log($"Error: {Message}");
        //}

        public void LogInformation(string Message)
        {
            Log($"Info: {Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"Warning: {Message}");
        }

        void ILogger.LogError(string Message)
        {
            Log($"Error: {Message}");
        }


        public override string ToString() => $"{Name} - {Height}";
    }
}
