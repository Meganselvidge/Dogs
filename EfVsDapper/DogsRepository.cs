using System.Data.Entity;
using System.Security.Cryptography;
using Dapper;
using Microsoft.EntityFrameworkCore;
using EfVsDapper;
using SQLitePCL;
using Microsoft.Data.Sqlite;

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

    public void EF_Read()
    {
        var dogs = _context.Dogs.FirstOrDefault(c => c.Name == "Rex");
        Console.WriteLine($"Name: {dogs?.Name}, Breed: {dogs?.Breed}, Age: {dogs?.Age}");
        
        
    }

    public void Dapper_Create()
    {
        using (var connection = new SqliteConnection("Data Source=Dogs.db"))
            
        {
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM Dogs WHERE Name = @Name";
            int count = connection.ExecuteScalar<int>(checkQuery, new { Name = "Elton" });  
            if (count > 0)
            {
                Console.WriteLine("The dog already exists in the database");
                return;
            }
            string insertQuery = "INSERT INTO Dogs (Name, Breed, Age) VALUES (@Name, @Breed, @Age)";
            connection.Execute(insertQuery, new { Name = "Elton", Breed = "sheltie", Age = 13 });
          
           
        }
    }
    public void Dapper_Read()
    {
        using (var connection = new SqliteConnection("Data Source=Dogs.db"))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Dogs WHERE Name = @Name";
            var dog = connection.QueryFirstOrDefault<Dog>(selectQuery, new { Name = "Elton" });
            Console.WriteLine($"Name: {dog?.Name}, Breed: {dog?.Breed}, Age: {dog?.Age}");
        }
    }
}
