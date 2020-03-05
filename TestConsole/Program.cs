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
            var rnd = new Random();

            var numbers_count = 100;
            var max_value = 51;

            var numbers = new List<int>();
            for (int i = 0; i < numbers_count; i++)
            {
                numbers.Add(rnd.Next(0, max_value));
            }

            var numbers_counts = new Dictionary<int, int>();
            var numbers_counts2 = new int[max_value];
            for (int i = 0; i < max_value; i++)
            {
                numbers_counts2[i] = 0;
            }



            for (int i = 0; i < numbers_count; i++)
            {
                var n = numbers[i];

                #region Первая реализация с помощью словаря
                if (numbers_counts.ContainsKey(n))
                {
                    numbers_counts[n]++;
                }
                else
                {
                    numbers_counts.Add(n, 1);
                }
                #endregion

                #region Вторая реализация с помощью массива
                numbers_counts2[n]++;
                #endregion

            }

            var count3 = GetItemCounts(numbers);
            
            var count4 = numbers.GroupBy(n => n)
                .Select(group => new { vaue = group.Key, count = group.Count() })
                .OrderBy(v => v.vaue)
                .ToArray();
            //  Словарь
            var count5 = numbers.GroupBy(n => n)
                .ToDictionary(group => group.Key, group => group.Count());

            Console.ReadKey();
        }

        private static Dictionary<T, int> GetItemCounts<T>(IEnumerable<T> items)
        {
            var result = new Dictionary<T, int>();
            foreach (var item in items)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result.Add(item, 1);
                }
            }
            return result;
        }
    }
}
