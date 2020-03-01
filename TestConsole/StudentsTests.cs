using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Extensions;

namespace TestConsole
{
    internal static class StudentsTests
    {
        public static void Run()
        {
            const string student_names_file = "names.txt";

            var file_with_names = new FileInfo(student_names_file);

            var rnd = new Random();
            var dekanat = new Dekanat();
            for (int i = 0; i < 10; i++)
            {
                dekanat.Add(new StudentsGroup { Name = $"Группа {i + 1}" });
            }

            foreach (var line in file_with_names.GetLines())
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var components = line.Split(' ');
                if (components.Length < 3)
                {
                    continue;
                }
                var student = new Student
                {
                    LastName = components[0],
                    FirstName = components[1],
                    Patronimyc = components[2],
                    Rating = rnd.GetRandomIntValues(10, 3, 6).ToList()
                };

                dekanat.Add(student);
            }

            //  перечисления студентов. можно работать с перечислениями.
            IEnumerable<Student> students_enum = dekanat;
            //   поддерживает запросы к себе. Оба интерфейсы.
            IQueryable<Student> students_query = students_enum.AsQueryable();

            foreach (var i in Enumerable.Range(0, 100))
            {
            }
            for (int i = 0; i < 100; i++)
            {
            }
            //  равносильные записи. Но основное предназначение Enumerable.Range() другое

        }
    }
}
