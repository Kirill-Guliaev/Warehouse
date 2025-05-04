using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.UnpaidItems;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class UnpaidItemsStorage : IUnpaidItemsStorage
{
    private readonly WarehouseDbContext dbContext;

    public UnpaidItemsStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Item>> GetUnpaidItems(Guid userId, CancellationToken cancellationToken)
    {
        return (await dbContext.Items
            .Where(i => !i.IsPaid && i.OwnerId == userId && i.ArrivedAt.HasValue && i.CheckedOutAt.HasValue)
            .ToListAsync(cancellationToken)).Select(s => s.ToItem());
    }

    public async Task<int> GetWarehousePriceAsync(Guid warehouseId)
    {
        var warehouse = await dbContext.Warehouses.FirstOrDefaultAsync(w=>w.WarehouseId == warehouseId)
            ?? throw new Exception("Warehouse is not found");
        return warehouse.PriceForUnit;
    }
}
