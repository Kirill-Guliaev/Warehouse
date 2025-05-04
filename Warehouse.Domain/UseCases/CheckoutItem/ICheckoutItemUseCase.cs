using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.CheckoutItem;

public interface ICheckoutItemUseCase
{
    Task<Item> ExecuteAsync(CheckoutItemCommand command, CancellationToken cancellationToken);
}
