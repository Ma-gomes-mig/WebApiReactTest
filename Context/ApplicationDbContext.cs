using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel
                {
                    StudentId = 1,
                    StudentName = "Miguel",
                    Email = "MiguelGomes@yahoo.com",
                    Age = 8
                },
                new StudentModel
                {
                    StudentId = 2,
                    StudentName = "Matheus",
                    Email = "Matheus.gom23@yahoo.com",
                    Age = 29
                });
        }
    }
}
