// See https://aka.ms/new-console-template for more information

using EfVsDapper;

Console.WriteLine("Hello, World!");
using (var context = new DogContext())
{
    context.Database.EnsureCreated();
}