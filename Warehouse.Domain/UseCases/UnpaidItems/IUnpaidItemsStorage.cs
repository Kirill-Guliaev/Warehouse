using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.UnpaidItems;

public interface IUnpaidItemsStorage
{
    Task<IEnumerable<Item>> GetUnpaidItems(Guid userId, CancellationToken cancellationToken);
   
    Task<int> GetWarehousePriceAsync(Guid key);
}
