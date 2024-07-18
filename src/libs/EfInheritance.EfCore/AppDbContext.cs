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
