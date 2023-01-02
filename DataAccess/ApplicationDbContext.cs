using DataAccess.Entities;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Student>? Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedTime = DateTime.UtcNow,
                    CreatedUserId = 1
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 2,
                    Name = "User",
                    CreatedTime = DateTime.UtcNow,
                    CreatedUserId = 1
                });

            var salt = Encryption.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin",
                    Username = "admin",
                    Salt = salt,
                    Hash = Encryption.GenerateHash("Admin12345", salt),
                    RoleId = 1,
                    CreatedTime = DateTime.UtcNow,
                    CreatedUserId = 1
                });
        }
    }
}