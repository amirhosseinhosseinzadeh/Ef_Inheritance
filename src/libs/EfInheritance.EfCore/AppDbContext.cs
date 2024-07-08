using System.Text.Json;
using EfInheritance.Domain;
using EfInheritance.Domain.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EfInheritance.EfCore;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Gadget>()
            .ToTable(nameof(Gadget))
            .UseTphMappingStrategy()
            .HasDiscriminator<string>("Gadget_Type") // also other value type, ypes are suitable to be assign to table as discriminator
            .HasValue<SmartPhone>("SmartPhone")
            .HasValue<SmartWatch>("SmartWatch");

        builder.Entity<SmartPhone>()
            .ToTable(nameof(Gadget))
            .Property(x => x.Color)
            .HasColumnName(nameof(SmartPhone.Color));

        builder.Entity<SmartPhone>()
            .HasData(new SmartPhone[]
            {
                new()
                {
                    Id = 1,
                    CameraSize = 20,
                    Color = "Rose Gold",
                    Name = "IPhone 14 pro max",
                    FrontCameraSize = 12,
                    Manufacturer = "Apple"
                },
                new()
                {
                    Id = 2,
                    CameraSize = 15,
                    Color = "metallic black",
                    Name = "Galaxy Note3",
                    FrontCameraSize = 7,
                    Manufacturer = "SamSung"
                }
            });


        builder.Entity<SmartWatch>()
            .HasData(new SmartWatch[]
            {
                new()
                {
                    Id = 3,
                    BandColor = "Silver",
                    CameraSize = 15,
                    Manufacturer = "Apple",
                    Color = "Silver",
                    HeartBeatSensor = true,
                    Name = "Iwatch 13"
                },
                new()
                {
                    Id = 4,
                    BandColor = "balck",
                    CameraSize = 15,
                    Manufacturer = "SamSung",
                    Color = "Gold",
                    HeartBeatSensor = false,
                    Name = "Galaxy Gear 3"
                },
            });

        builder.Entity<SmartWatch>()
            .ToTable(nameof(Gadget))
            .Property(x => x.Color)
            .HasColumnName(nameof(SmartPhone.Color));



    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        using IOHandler<JsonDocument> iOHandler = new IOJsonHandler();
        iOHandler.GetConnectionStringFacadeAsync().ContinueWith(x =>
        {
            if (x.IsCompletedSuccessfully)
                optionsBuilder.UseSqlServer(x.Result);
            else
                throw x.Exception;
        }).Wait();
        base.OnConfiguring(optionsBuilder);
    }
}
