using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeesContext :DbContext
    {
        public EmployeesContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employees>());
            new UserInfoEntityConfiguration().Configure(modelBuilder.Entity<UserInfo>());
        }
    }
}
