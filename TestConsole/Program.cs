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
            var dekanat = new Dekanat();

            for (int i = 0; i < 100; i++)
            {
                dekanat.Add(new Student { Name = $"Student {i + 1}", });
            }
            const string students_data_file = "students.csv";
            dekanat.SaveToFile(students_data_file);

            Console.ReadKey();
        }
    }
}
