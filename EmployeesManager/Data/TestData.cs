using EmployeesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Data
{
    static class TestData
    {
        public static List<Employee> Employees { get; } = Enumerable.Range(1, 100)
            .Select(i => new Employee 
            { 
                Id = i, 
                SurName = $"Фамилия {i}", 
                Name = $"Имя {i}", 
                Patronymic = $"Отчество {i}",
                DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 / 6 * (i + 18)))
            })
            .ToList();
    }
}
