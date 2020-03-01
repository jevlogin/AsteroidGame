using System;
using System.Collections.Generic;
using System.IO;

namespace TestConsole
{
    class Dekanat : Storage<Student>
    {
        public event Action<Student> ExcelentStudent;

        public Dekanat()
        {
            NewItemAdded += OnNewItemAdded;
        }

        private void OnNewItemAdded(Student student)
        {
            if (student.AverageRating > 4.5)
            {
                ExcelentStudent?.Invoke(student);
            }
        }

        public override void SaveToFile(string FileName)
        {
            //  Упрощенный вариант
            using (var file_writer = File.CreateText(FileName))
            {
                foreach (var student in _Items)
                {
                    file_writer.Write(student.Name);
                    if (student.Rating.Count > 0)
                    {
                        var ratings_string = string.Join(",", student.Rating);
                        file_writer.Write($",{ratings_string}");
                    }
                    file_writer.WriteLine();
                }
            }
        }

        public override void LoadFromFile(string FileName)
        {
            if (!File.Exists(FileName))
            {
                return;
            }
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("Файл с данными деканата не найден", FileName);
            }
            base.LoadFromFile(FileName);

            //  Упрощенный вариант
            using (var file_reader = File.OpenText(FileName))
            {
                while (!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    var data_elements = str.Split(',');
                    if (data_elements.Length == 0)
                    {
                        continue;
                    }
                    var student = new Student { Name = data_elements[0] };
                    if (data_elements.Length > 1)
                    {
                        var ratings = new List<int>();
                        for (int i = 1; i < data_elements.Length; i++)
                        {
                            ratings.Add(int.Parse(data_elements[i]));
                        }
                        student.Rating = ratings;
                    }
                    Add(student);
                }
            }
        }
    }
}
