using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF6TestApp.Entities
{
    class Departament
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
