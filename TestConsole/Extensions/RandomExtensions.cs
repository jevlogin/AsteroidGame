using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Extensions
{
    static class RandomExtensions
    {
        public static IEnumerable<int> GetRandomIntValues(this Random rnd, int Count, int Min, int Max)
        {
            for (int i = 0; i < Count; i++)
            {
                //  Ключевое слово yield позволяет преобразовать метод GetRandomIntValues(Random rnd, int Count, int Min, int Max) 
                //  в специальный класс
                yield return rnd.Next(Min, Max);
            }
        }
    }
}
