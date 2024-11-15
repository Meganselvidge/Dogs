using Microsoft.EntityFrameworkCore;

namespace EfVsDapper
{
    public class DogContext : DbContext
    {
        // Definiera DbSet för Dog-tabellen
        public DbSet<Dog> Dogs { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfigurera SQLite-databasen
            optionsBuilder.UseSqlite("Data Source=Dogs.db");
        }
    }
}