using Microsoft.EntityFrameworkCore;
using EfVsDapper;
namespace EfVsDapper;

public class DogsRepository
{
    private readonly DogContext _context;

    public DogsRepository()
    {
        _context = new DogContext();
        _context.Database.EnsureCreated(); // Säkerställ att databasen och tabellen skapas
    }

    public void EF_Create()
    {
        var dog = new Dog
        {
            Name = "Rex",
            Breed = "German Shepherd",
            Age = 5
        };
       
        if 
        (_context.Dogs.Any(d => d.Name == dog.Name)) return; // Om hunden redan finns, avbryt


        _context.Dogs.Add(dog); // Lägg till hunden i databasen
        _context.SaveChanges(); // Spara ändringar
    }
}