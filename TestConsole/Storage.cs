using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TestConsole
{
    abstract class Storage<TItem> : IEnumerable<TItem>
    {
        protected readonly List<TItem> _Items = new List<TItem>();

        public void Add(TItem Item)
        {
            if (_Items.Contains(Item))
            {
                return;
            }
            _Items.Add(Item);
        }
        public bool Remove(TItem Item)
        {
            return _Items.Remove(Item);
        }

        public bool IsContains(TItem Item) => _Items.Contains(Item);

        public void Clear()
        {
            _Items.Clear();
        }
        public abstract void SaveToFile(string FileName);

        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            for (int i = 0; i < _Items.Count; i++)
            {
                //  yield - специальный модификатор
                yield return _Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Dekanat : Storage<Student>
    {
        public override void SaveToFile(string FileName)
        {

            ////  Полноценный вариант
            //using (var file_stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    using (var writer = new StreamWriter(file_stream))
            //    {
            //        //  А вот тут была бы работа с текстом
            //    }
            //}

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

            ////  Полноценный вариант, в случае когда захотим использовать буфер, придется писать ручками
            //using (var file_stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    using(var buffer_stream = new BufferedStream(file_stream, 1024 * 1024))
            //    {
            //        using (var reader = new StreamReader(file_stream))
            //        {
            //            //  Читаем файл
            //        }
            //    }
            //}

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
