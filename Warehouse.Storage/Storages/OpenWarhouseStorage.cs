using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.UseCases.OpenWarehouse;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class OpenWarhouseStorage : IOpenWarhouseStorage
{
    private readonly WarehouseDbContext dbContext;

    public OpenWarhouseStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Domain.Models.Warehouse> OpenWarhouseAsync(Guid userId, int price, int size, CancellationToken cancellationToken)
    {
        var owner = await dbContext.Persons.FirstOrDefaultAsync(u => u.PersonId == userId)
            ?? throw new Exception("User not found");
        var newWarehouse = new Entities.Warehouse()
        {
            OwnerId = userId,
            StorageVolume = size,
            PriceForUnit = price,
        };
        owner.Warehouses.Add(newWarehouse);
        await dbContext.SaveChangesAsync();
        return newWarehouse.ToWarehouse(size);
    }
}
