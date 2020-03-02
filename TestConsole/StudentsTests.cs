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

            #region Enumerable.Range(1, 100)
            /*
            //  перечисления студентов. можно работать с перечислениями.
            IEnumerable<Student> students_enum = dekanat;
            //   поддерживает запросы к себе. Оба интерфейсы.
            IQueryable<Student> students_query = students_enum.AsQueryable();

            //  равносильные записи. Но основное предназначение Enumerable.Range() другое
            foreach (var i in Enumerable.Range(0, 100))
            {
            }
            for (int i = 0; i < 100; i++)
            {
            }

            var simple_students = Enumerable.Range(1, 100)
                .Select(i => new Student { FirstName = $"Student {i}" })
                .ToArray() ;   //  получили объект перечисления студентов

            foreach (var students in simple_students)
            {
                Console.WriteLine(students);
            }
            */
            #endregion

            var best_students = dekanat.Where(student => student.AverageRating > 4);
            var loser_students = dekanat.Where(student => student.AverageRating < 4);
            foreach (var best_student in best_students)
            {
                Console.WriteLine(best_student);
            }
            foreach (var losers in loser_students)
            {
                Console.WriteLine(losers);
            }

            //  подсчет хорошистов и лузеров
            var best_count = best_students.Count();
            var loser_count = loser_students.Count();

            #region .Select Where OrderBy Sum
            /*
            //  var автоматическая типизация
            var names_length = file_with_names.GetLines()
                .Select(str => str.Split(' '))  //  разделили по пробелу
                .Select(strs => new KeyValuePair<string, int>(strs[1], strs[1].Length)) //  выбрали второй элемент (имя)
                .Where(v => v.Value > 4)    //  выбрали те что больше 4 фильтрация
                .OrderBy(v => v.Value)  //  отсортировали
                .Sum(v => v.Key.Length);
            */
            #endregion

            IEnumerable<Student> students = dekanat;
            IEnumerable<StudentsGroup> groups = dekanat.Groups;

            var sudents_group = dekanat.Join(
                groups,
                stud => stud.GroupId,
                group => group.Id,
                (stud, group) => new { Student = stud, Group = group }
                );

            foreach (var students_group in sudents_group)
            {
                Console.WriteLine($"{students_group.Student} == {students_group.Group}");
            }

            //  2:31:19
        }
    }
}
