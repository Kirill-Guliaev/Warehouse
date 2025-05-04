using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.RegisterItem;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class RegisterItemStorage : IRegisterItemStorage
{
    private readonly WarehouseDbContext warehouseDbContext;

    public RegisterItemStorage(WarehouseDbContext warehouseDbContext)
    {
        this.warehouseDbContext = warehouseDbContext;
    }

    public async Task<Item> RegisterItemAsync(Guid userId, string name, int size, Guid warehouseId, CancellationToken cancellationToken)
    {
        var itemId = Guid.NewGuid();
        var newItem = new Entities.Item()
        {
            Size = size,
            Name = name,
            OwnerId = userId,
            ItemId = itemId,
            WarehouseId = warehouseId
        };
        await warehouseDbContext.Items.AddAsync(newItem);
        await warehouseDbContext.SaveChangesAsync();
        return newItem.ToItem();
    }

    public async Task ThrowIfWarehouseNotAvailable(Guid warehouseId, int size, CancellationToken cancellationToken)
    {
        var warehouse = await warehouseDbContext.Warehouses.FirstOrDefaultAsync(w => w.WarehouseId == warehouseId)
           ?? throw new Exception("warehouse is not found");
        var sum = warehouse.Items.Sum(i => i.Size);
        if(sum + size > warehouse.StorageVolume)
        {
            throw new Exception("Warehouse is full");
        }
    }
}
