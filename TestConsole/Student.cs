using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>, ICloneable<Student>
    /*IComparable*/
    {
        public string Name { get; set; }

        public List<int> Rating { get; set; } = new List<int>();

        //  Подсчет среднего бала автоматическим способом через IEnumerator
        public double AverageRating /*=> Rating.Average();*/
        {
            get
            {
                //return Rating.Average();
                return Rating.Sum() / (double)Rating.Count;
            }
        }

        public object Clone()
        {
            return new Student
            {
                Name = Name,
                Rating = new List<int>(Rating)
            };
        }

        public Student CloneObject()
        {
            return (Student)Clone();
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

        public override string ToString() => $"{Name}: {AverageRating:0.##}";
    }
}
