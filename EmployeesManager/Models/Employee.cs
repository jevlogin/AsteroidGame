using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int Age => (int)Math.Floor((DateTime.Now - DayOfBirth).TotalDays / 365);

        public override string ToString()
        {
            return $"Сотрудник [{Id}] - {SurName}";
        }
    }
}
