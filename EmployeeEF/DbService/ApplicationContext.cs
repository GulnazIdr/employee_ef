using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEF.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEF.DbService
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Employee> employee { get; set; } = null!;
        public DbSet<Title> title { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=title_personal_idrisova;Username=postgres;Password=12");
        }

        public ApplicationContext GetContext()
        {
            return this;
        }
    }
}
