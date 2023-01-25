using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AlunoModel> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoModel>().HasData(
                new AlunoModel
                {
                    AlunoId = 1,
                    AlunoName = "Miguel",
                    Email = "MiguelGomes@yahoo.com",
                    Idade = 8
                },
                new AlunoModel
                {
                    AlunoId = 2,
                    AlunoName = "Matheus",
                    Email = "Matheus.gom23@yahoo.com",
                    Idade = 29
                });
        }
    }
}
