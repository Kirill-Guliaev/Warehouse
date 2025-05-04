using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.UseCases.EditWarehouse;
using Warehouse.Storage.Entities;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class EditWarehouseStorage : IEditWarehouseStorage
{
    private readonly WarehouseDbContext dbContext;

    public EditWarehouseStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Domain.Models.Warehouse> EditWarehouseAsync(Guid warehouseId, int newPrice, int newSize, CancellationToken cancellationToken)
    {
        var warehouse = await dbContext.Warehouses.FirstOrDefaultAsync(w => w.WarehouseId == warehouseId, cancellationToken)
            ?? throw new Exception("Warehouse is null");
        warehouse.StorageVolume = newSize;
        warehouse.PriceForUnit = newPrice;
        await dbContext.SaveChangesAsync();
        return warehouse.ToWarehouse(warehouse.GetAvailableSpace());
    }

    public async Task<Domain.Models.Warehouse> GetWarehouseAsync(Guid warehouseId, CancellationToken cancellationToken)
    {
        var res = await dbContext.Warehouses
            .Include(w=>w.Items)
            .FirstOrDefaultAsync(w => w.WarehouseId == warehouseId, cancellationToken)
            ?? throw new Exception("Warehouse is null");
        return res.ToWarehouse(res.GetAvailableSpace());
    }
}
