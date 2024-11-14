
namespace EfVsDapper;

public class DogsRepository
{
    private readonly DogContext _context;
    public DogsRepository()
    {
        _context = new DogContext();
    }

    public void EF_Create()
    {
        var dog = new Dog();
        name = "Rex";
        Breed = "German Shepherd";
        Age = 5;
        _context.Dogs.Add(dog);
        _context.SaveChanges(); 
    }
    
}