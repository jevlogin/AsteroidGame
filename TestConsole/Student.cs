using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student
    {
        public string Name { get; set; }

        public List<int> Rating { get; set; } = new List<int>();

        public double AverageRating
        {
            get
            {
                var ratings = Rating;
                if (ratings == null)
                {
                    throw new InvalidOperationException("Невозможно рассчитать среднюю оценку. Список оценок не задан.");
                }
                if (ratings.Count == 0)
                {
                    return double.NaN;
                }
                var sum = 0;
                for (int i = 0; i < ratings.Count; i++)
                {
                    sum += ratings[i];
                }
                return sum / (double)ratings.Count;
            }
        }

        public override string ToString() => $"{Name}: {AverageRating:0.##}";
    }
}
