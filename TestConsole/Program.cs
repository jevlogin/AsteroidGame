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

        private static void OnStudentAdd(Student Student)
        {
            Console.WriteLine("Студент {0} добавлен", Student.Name);
        }

        private static void OnStudentRemoved(Student Student)
        {
            Console.WriteLine("Студент {0} исключен", Student.Name);
        }
        private static void GoToVoenkomat(Student Student)
        {
            Console.WriteLine("Студент {0} отправлен служить в армию", Student.Name);
        }

        static void Main(string[] args)
        {
            var dekanat = new Dekanat();
            //dekanat.SubscribeToAdd(OnStudentAdd);
            dekanat.SubscribeToRemove(OnStudentRemoved);
            dekanat.SubscribeToRemove(GoToVoenkomat);
            //dekanat.SubscribeToAdd(std => Console.WriteLine("Еще раз поздравляем студента {0} с поступлением", std.Name));

            dekanat.NewItemAdded += OnStudentAdd;
            dekanat.ExcelentStudent += excelent_student => Console.WriteLine("!!! {0} !!!", excelent_student);

            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                dekanat.Add(new Student
                {
                    Name = $"Student {i + 1}",
                    Rating = rnd.GetRandomIntValues(20, 2, 6).ToList() //GetRandomRatings(rnd, 20, 50)
                });
            }

            dekanat.Add(new Student { Name = "Strange student", Rating = new List<int> { 5, 5, 5, 5, 4, 5, 5 } });

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

            #region старое
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

            //Console.ReadLine();
            //ProcessStudents(dekanat2, GetIndexStudentName);

            //Console.ReadLine();
            //ProcessStudents(dekanat2, GetAverageStudentRating); //  делегат в делегате

            //ProcessStudentsStandard(dekanat2, PrintStudent);

            //Console.Clear();

            //var metrics = GetStudentsMetrics(dekanat2, std => std.Name.Length + (int)(student.AverageRating * 10)); //  Мой мозг улетел в космос и взорвался об астероид
            #endregion

            //Console.Clear();
            Console.ReadKey();

            var student_to_remove = dekanat.Skip(65).First();
            dekanat.Remove(student_to_remove);


            Console.ReadKey();
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("Студент: {0}", student.Name);
        }

        public static void ProcessStudentsStandard(IEnumerable<Student> Students, Action<Student> action)
        {
            foreach (var s in Students)
            {
                action(s);
            }
        }

        public static int[] GetStudentsMetrics(IEnumerable<Student> Students, Func<Student, int> GetMetric)
        {
            var result = new List<int>();
            foreach (var student in Students)
            {
                result.Add(GetMetric(student));
            }
            return result.ToArray();
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
