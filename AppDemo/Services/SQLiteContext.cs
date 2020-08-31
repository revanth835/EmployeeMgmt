using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Employee> EmployeeDBModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=advertdb.db");
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Skillsets { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
