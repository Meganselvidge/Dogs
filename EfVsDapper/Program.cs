namespace EfVsDapper;

public class Program
{
    public static void Main(string[] args)
    {
        var repository = new DogsRepository();
        repository.EF_Create();
        
        Console.WriteLine("A dog has been added to the database!");
        repository.EF_Read();
        repository.Dapper_Create();
        Console.WriteLine("A dog has been added to the database!");
       
        repository.Dapper_Read();
    }
}