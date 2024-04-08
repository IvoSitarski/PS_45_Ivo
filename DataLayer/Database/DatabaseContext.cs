using DataLayer.Loggers;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

        private char key = 'K'; // XOR криптиране/декриптиране

        public void Log(string action)
        {
            LogEntries.Add(new LogEntry { Action = action, Timestamp = DateTime.Now });
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath=Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data source = {databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                Names = "John Doe",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Email="jDoe@tu-sofia.bg",
                FacultyNumber="121221222",
                Expires = DateTime.Now.AddYears(10),
                IsActive = true
            };

            var user2 = new DatabaseUser()
            {
                Id = 2,
                Names = "Ivan Petrov",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                Email = "iPetrov@tu-sofia",
                FacultyNumber="121221333",
                Expires = DateTime.Now.AddYears(10),
                IsActive = true
            };

            var user3 = new DatabaseUser()
            {
                Id = 3,
                Names = "Petar Stoqnov",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                Email ="pStoqnov",
                FacultyNumber="121221123",
                Expires = DateTime.Now.AddYears(10),
                IsActive = true
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);
            modelBuilder.Entity<DatabaseUser>().HasData(user3);
        }

       
        public string EncryptDecrypt(string input)
        {
            var output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key);
            }
            return new string(output);
        }
    }
}
