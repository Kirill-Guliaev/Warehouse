using Microsoft.EntityFrameworkCore;
using Warehouse.Storage.Entities;

namespace Warehouse.Storage;

public class WearhouseDbContext : DbContext
{
    public WearhouseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Wearhouse> Wearhouses { get; set; } = null!;
}
