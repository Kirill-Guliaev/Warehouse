using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.ConfirmPay;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class ConfirmPayItemStorage : IConfirmPayItemStorage
{
    private readonly WarehouseDbContext dbContext;

    public ConfirmPayItemStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Item> ConfirmPayAsync(Guid itemId, Guid warehouseId, CancellationToken cancellationToken)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(i => i.ItemId == itemId && i.WarehouseId == warehouseId)
            ?? throw new Exception("Item not found");
        item.IsPaid = true;
        await dbContext.SaveChangesAsync();
        return item.ToItem();
    }
}
