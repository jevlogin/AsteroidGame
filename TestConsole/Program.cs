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
        public static List<int> GetRandomRatings(Random rnd, int CountMin, int CountMax)
        {
            var count = rnd.Next(CountMin, CountMax + 1);
            var result = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                result.Add(rnd.Next(2, 6));
            }
            return result;
        }
        static void Main(string[] args)
        {
            var dekanat = new Dekanat();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                dekanat.Add(new Student { Name = $"Student {i + 1}", Rating = GetRandomRatings(rnd, 20, 50)});
            }
            const string students_data_file = "students.csv";
            dekanat.SaveToFile(students_data_file);

            var dekanat2 = new Dekanat();
            dekanat2.LoadFromFile(students_data_file);

            var student = new Student { Name = $"Student", Rating = GetRandomRatings(rnd, 20, 50) };

            var result = student.CompareTo(dekanat);
            Console.ReadKey();
        }
    }
}
