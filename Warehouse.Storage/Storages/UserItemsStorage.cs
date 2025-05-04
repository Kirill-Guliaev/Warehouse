using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Domain.UseCases.GetUserItems;
using Warehouse.Storage.Mapper;

namespace Warehouse.Storage.Storages;

public class UserItemsStorage : IUserItemsStorage
{
    private readonly WarehouseDbContext warehouseDbContext;

    public UserItemsStorage(WarehouseDbContext warehouseDbContext)
    {
        this.warehouseDbContext = warehouseDbContext;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(Guid userId, CancellationToken cancellationToken)
    {
        var person = await warehouseDbContext.Persons.Include(p => p.Items).FirstOrDefaultAsync(x => x.PersonId == userId)
            ?? throw new Exception("User not found");
        return person.Items.Select(i => i.ToItem());
    }
}
