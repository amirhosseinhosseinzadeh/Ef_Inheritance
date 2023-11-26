using EfInheritance.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfInheritance.EfCore;

public class AppDbContext : DbContext
{

    public DbSet<SmartPhone> SmartPhones { get; set; }

    public DbSet<SmartWatch> SmartWatch { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<SmartWatch>()
            .ToTable("SmartWatch")
            .HasData(new SmartWatch[]
            {
                new()
                {
                    Color = "Gold",
                    Name= "Galaxy Gear3",
                    Manufacturer = "SamSung",
                    Id = 1
                }
            });

        builder.Entity<SmartPhone>()
            .ToTable("SmartPhone")
            .HasData(new SmartPhone[]
            {
                new()
                {
                    Id = 1,
                   Manufacturer = "Apple",
                   Name = "Iphone 4",
                   CameraSize = 24,
                   Color = "Black"
                }
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=db-dev;database = tpt; Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
    }
}
