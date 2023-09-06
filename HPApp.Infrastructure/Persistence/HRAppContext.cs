using HRApp.Application.Interfaces;
using HRApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPApp.Infrastructure.Persistence
{
    public class HRAppContext: DbContext, IHRAppContext 
    {
        public HRAppContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(_=>_.LastName).HasMaxLength(25);
            modelBuilder.Entity<Employee>().Property(_ => _.FirstName).HasMaxLength(25);
            modelBuilder.Entity<Employee>().Property(_ => _.Patronymic).HasMaxLength(25);
            modelBuilder.Entity<Employee>().Property(_ => _.UserModified).HasMaxLength(25);

            modelBuilder.Entity<Post>().Property(_ => _.Name).HasMaxLength(50);
            modelBuilder.Entity<Post>().Property(_ => _.UserModified).HasMaxLength(25);
        }

    }
}
