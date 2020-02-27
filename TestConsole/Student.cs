using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>
    /*IComparable*/
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

        public int CompareTo(Student other)
        {
            var current_average_rating = AverageRating;
            var other_average_rating = other.AverageRating;

            if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
            {
                return 0;
            }
            if (current_average_rating > other_average_rating)
            {
                return +1;
            }
            else
            {
                return -1;
            }
        }

        public bool Equals(Student other) => other?.Name == Name;

        public bool Equals(string other)
        {
            return Name == other;
        }

        //{
        //    //return other?.Name == Name;

        //    //  через тернарный оператор
        //    //return (other == null ? null : other.Name) == Name;

        //    //  подробно подробно
        //    if (other == null)
        //    {
        //        return null == Name;
        //    }
        //    else
        //    {
        //        return other.Name == Name;
        //    }
        //}

        //public int CompareTo(object obj)
        //{
        //    var other_student = (Student)obj;
        //    var current_average_rating = AverageRating;
        //    var other_average_rating = other_student.AverageRating;

        //    if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
        //    {
        //        return 0;
        //    }
        //    if (current_average_rating > other_average_rating)
        //    {
        //        return +1;
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        public override string ToString() => $"{Name}: {AverageRating:0.##}";
    }
}
