using Logistically.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistically.WebApi.Data.Contexts;

public class PackageDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(Constants.PackageDb);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Package>().HasKey(x => x.ParcelId);
    }

    public DbSet<Package> Packages => Set<Package>();
}
