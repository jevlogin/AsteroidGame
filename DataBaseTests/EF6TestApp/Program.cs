using EF6TestApp.Data;
using EF6TestApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                //if (!db.Departaments.Any())
                //{
                //    foreach (var dep in Enumerable.Range(1, 10).Select(i => new Departament { Name = $"Отдел {i}" }))
                //    {
                //        db.Departaments.Add(dep);
                //    }
                //    db.SaveChanges();
                //}
                if (!db.Employees.Any())
                {
                    var rnd = new Random();
                    foreach (var employee in Enumerable.Range(1, 100).Select(i => new Employee 
                    { 
                        Name = $"Сотрудник {i}", 
                        DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 *  rnd.Next(18, 30))),
                    }))
                    {
                        var dep_id = rnd.Next(1, 10);
                        employee.Departament = db.Departaments.FirstOrDefault(d => d.Id == dep_id);
                        db.Employees.Add(employee);
                    }
                    db.SaveChanges();
                }
            }

            using (var db = new DatabaseContext())
            {
                2-55-55
            }
        }
    }
}
