using EfInheritance.Domain;
using EfInheritance.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EfInheritance.EfCore;

public class AppDbContext : DbContext
{

    public DbSet<Policy> Policy { get; set; }

    public DbSet<Endorsement> Endorsement { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Policy>()
            .UseTptMappingStrategy()
            .ToTable(nameof(Policy));
        builder.Entity<Endorsement>()
            .ToTable(nameof(Endorsement));

        builder.Entity<Policy>()
            .HasData(new Policy[]
            {
                new()
                {
                    Id= 1,
                    CoveringAmount = 5000,
                    EffectionDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    Title = "Vehicle Thired party inssurance"
                }
            });
        builder.Entity<Endorsement>()
            .HasData(new Endorsement[]
            {
                new()
                {
                    Id = 2,
                    EndorsementCoveringAmount = 6000,
                    EndorsementEndDate = DateTime.Now.AddMonths(1).AddYears(2),
                    EndorsementEffectionDate = DateTime.Now.AddMonths(1),
                    EndorsementRegsterDate = DateTime.Now
                }
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Policy<JsonDocument> iOHandler = new IOJsonHandler();
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
