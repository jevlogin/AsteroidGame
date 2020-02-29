using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            //var simple_array_list = new ArrayList();

            //simple_array_list.Add(42);
            //simple_array_list.Add(new object());
            //simple_array_list.Add(3.14456465468);
            //simple_array_list.Add("Hello World!");

            //for (int i = 0; i < simple_array_list.Count; i++)
            //{
            //    var value = simple_array_list[i];
            //    if (value is int)
            //    {
            //        int v = (int)value;
            //        Console.WriteLine($"Int: {v}");
            //    }
            //    else if (value is string)
            //    {
            //        string v = (string)value;
            //        Console.WriteLine($"String: {v}");
            //    }
            //    else if (value is double)
            //    {
            //        double v = (double)value;
            //        Console.WriteLine($"Double: {v}");
            //    }
            //    else if(value is object)
            //    {
            //        object v = (object)value;
            //        Console.WriteLine($"Object: {v}");
            //    }
            //}

            List<Student> students = new List<Student>(45);

            for (int i = 0; i < 46; i++)
            {
                students.Add(new Student());
            }

            var students_to_add = new Student[20];
            for (int i = 0; i < students_to_add.Length; i++)
            {
                students_to_add[i] = new Student();
            }
            //  Добавление массива  в список одним пакетом. Увеличение быстродействия. Всегда проверять возможно ли такое?
            students.AddRange(students_to_add);

            students.Capacity = students.Count; // выравнивание кол-ва элементов для сохранения памяти в оперативной памяти

            //  список будет создан на основе любого перечисления
            var new_students_list = new List<Student>(students_to_add);
            students.RemoveAt(5);

            var number_list = new List<int>(1000);
            for (int i = 0; i < number_list.Capacity; i++)
            {
                number_list.Add(i+22);
            }
            var value_index = number_list.BinarySearch(712);
            
            var string_list = new List<string>(1000);
            for (int i = 0; i < string_list.Capacity; i++)
            {
                string_list.Add($"Message {i + 22}");
            }
            string_list.Sort(); //  странно после сортировки индекс изменяется на 687 до этого 690
            string_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2, s1));   //  перевернули список

            //var strings_array = string_list.ToArray();
            var strings_array = new string[string_list.Count];
            string_list.CopyTo(strings_array, 0);

            var str_value_index = string_list.BinarySearch("Message 712");
             
            Console.ReadKey();
        }
    }
}
