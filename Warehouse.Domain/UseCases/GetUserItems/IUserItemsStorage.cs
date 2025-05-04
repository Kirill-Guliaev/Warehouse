using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.GetUserItems;

public interface IUserItemsStorage
{
    Task<IEnumerable<Item>> GetItemsAsync(Guid userId, CancellationToken cancellationToken);
}