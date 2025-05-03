using Microsoft.EntityFrameworkCore;
using Warehouse.Storage.Entities;

namespace Warehouse.Storage;

public class WarehouseDbContext : DbContext
{
    public WarehouseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Entities.Warehouse> Warehouses { get; set; } = null!;
}
