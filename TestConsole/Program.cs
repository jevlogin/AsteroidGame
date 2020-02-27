﻿using System;
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

            var random_student_name = rnd.NextValue("Иванов", "Петров", "Сидоров");

            var random_rating = rnd.NextValue(2, 4, 5, 7, 2);

            // равносильные записи. Использование ДЕЛЕГАТА
            //StudentProcessor processor = new StudentProcessor(GetIndexStudentName);
            //StudentProcessor processor = GetIndexStudentName;

            //var Index = 0;
            //foreach (var s in dekanat2)
            //{
            //    Console.WriteLine(processor(s, Index++));
            //}
            //Console.ReadLine();

            //processor = GetAverageStudentRating;
            //Index = 0;
            //foreach (var s in dekanat2)
            //{
            //    Console.WriteLine(processor(s, Index++));
            //}

            Console.ReadLine();
            ProcessStudents(dekanat2, GetIndexStudentName);

            Console.ReadLine();
            ProcessStudents(dekanat2, GetAverageStudentRating); //  делегат в делегате

            Console.ReadKey();
        }

        public static void ProcessStudents(IEnumerable<Student> Students, StudentProcessor Processor)
        {
            var Index = 0;
            foreach (var s in Students)
            {
                Console.WriteLine(Processor(s, Index++));
            }
        }

        private static string GetIndexStudentName(Student student, int Index)
        {
            return $"{student.Name}[{Index}]";
        }

        public static string GetAverageStudentRating(Student student, int Index)
        {
            return $"[{Index}]:{student.Name} - {student.AverageRating}";
        }
    }

    internal delegate string StudentProcessor(Student Student, int Index);
}
