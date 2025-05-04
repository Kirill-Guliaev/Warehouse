using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.AcceptRegisteredItem;

public interface IAcceptRegisteredItemStorage
{
    Task<Item> AcceptRegisteredItemAsync(Guid id, CancellationToken cancellationToken);
}