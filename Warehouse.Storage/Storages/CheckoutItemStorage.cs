using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.CheckoutItem;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class CheckoutItemStorage : ICheckoutItemStorage
{
    private readonly WarehouseDbContext dbContext;

    public CheckoutItemStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Item> CheckoutItemAsync(Guid itemId, Guid warehouseId, CancellationToken cancellationToken)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(i => i.ItemId == itemId && i.WarehouseId == warehouseId, cancellationToken) ?? throw new Exception("Item not found");
        item.CheckedOutAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
        return item.ToItem();
    }
}
