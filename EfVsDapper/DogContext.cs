using Microsoft.EntityFrameworkCore;

namespace EfVsDapper;

public class DogContext: DbContext
{
    public DogContext(DbSet<Dog> dog)
    {
        Dog = dog;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       
    optionsBuilder.UseSqlite("Data Source=Dogs.db");  
    }
}