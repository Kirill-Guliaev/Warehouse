using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.RegisterItem;

public interface IRegisterItemStorage
{
    Task<Item> RegisterItemAsync(Guid userId, string name, int size, Guid warehouseId, CancellationToken cancellationToken);

    Task ThrowIfWarehouseNotAvailable(Guid warehouseId, int size, CancellationToken cancellationToken);
}