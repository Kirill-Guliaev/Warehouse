using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.CheckoutItem;

public interface ICheckoutItemStorage
{
    Task<Item> CheckoutItemAsync(Guid itemId, Guid warehouseId, CancellationToken cancellationToken);
}
