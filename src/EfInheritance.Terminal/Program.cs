using EfInheritance.EfCore;
using Microsoft.EntityFrameworkCore;

using var dbContext = new AppDbContext();
try
{
    await dbContext.Database.MigrateAsync();
    Console.WriteLine("Migration being complete !");
}
catch(Exception ex)
{
    Console.WriteLine("ooooooooops !");
    Console.WriteLine(ex.Message);
}