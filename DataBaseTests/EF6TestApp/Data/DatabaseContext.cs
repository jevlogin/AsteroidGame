using EF6TestApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TestApp.Data
{
    class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DatabaseContext() : this("DefaultConnection")
        {

        }
        public DatabaseContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
