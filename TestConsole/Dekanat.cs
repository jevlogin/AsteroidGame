using System;
using System.Collections.Generic;
using System.IO;
using TestConsole.Extensions;

namespace TestConsole
{
    class Dekanat : Storage<Student>
    {
        private readonly List<StudentsGroup> _Groups = new List<StudentsGroup>();

        public IEnumerable<StudentsGroup> Groups => _Groups;

        public event Action<Student> ExcelentStudent;
        public Dekanat()
        {
            NewItemAdded += OnNewItemAdded;
        }
        public void Add(StudentsGroup group)
        {
            if (_Groups.Contains(group))
            {
                return;
            }
            _Groups.Add(group);
            group.Id = _Groups.Count;
        }
        private void OnNewItemAdded(Student student)
        {
            var max_index = 0;
            foreach (var s in _Items)
            {
                max_index = Math.Max(max_index, s.Id);
            }
            student.Id = max_index + 1;

            var random_group = new Random().NextValue(_Groups.ToArray());

            student.GroupId = random_group.Id;

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
                    file_writer.Write(student.FirstName);
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
                    var student = new Student { FirstName = data_elements[0] };
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
