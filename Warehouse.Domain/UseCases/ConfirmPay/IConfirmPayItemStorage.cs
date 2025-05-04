using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.ConfirmPay;

public interface IConfirmPayItemStorage
{
    Task<Item> ConfirmPayAsync(Guid itemId, Guid warehouseId, CancellationToken cancellationToken);
}
