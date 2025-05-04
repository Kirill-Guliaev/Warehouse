using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.AcceptRegisteredItem;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class AcceptRegisteredItemStorage : IAcceptRegisteredItemStorage
{
    private readonly WarehouseDbContext dbContext;

    public AcceptRegisteredItemStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Item> AcceptRegisteredItemAsync(Guid id, CancellationToken cancellationToken)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(i => i.ItemId == id, cancellationToken) ?? throw new Exception("Item not found");
        item.ArrivedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
        return item.ToItem();
    }
}
