using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Loggers;
using TestConsole.Extensions;

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
                dekanat.Add(new Student
                {
                    Name = $"Student {i + 1}",
                    Rating = rnd.GetRandomIntValues(20, 2, 6).ToList() //GetRandomRatings(rnd, 20, 50)
                });
            }
            const string students_data_file = "students.csv";
            dekanat.SaveToFile(students_data_file);

            var dekanat2 = new Dekanat();
            dekanat2.LoadFromFile(students_data_file);

            var student = new Student { Name = $"Student", Rating = GetRandomRatings(rnd, 20, 50) };

            //var result = student.CompareTo(dekanat);

            foreach (var std in dekanat2)
            {
                Console.WriteLine(std);
            }

            var average_rating = dekanat2.Average(s => s.AverageRating);    //YAHOOEYU просто космические записи ))
            var sum_average_rating = dekanat2.Sum(s => s.AverageRating);


            Console.ReadKey();
        }
    }
}
