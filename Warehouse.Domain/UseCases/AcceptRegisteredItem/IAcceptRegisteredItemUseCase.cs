using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.AcceptRegisteredItem;

public interface IAcceptRegisteredItemUseCase
{
    Task<Item> ExecuteAsync(AcceptRegisteredItemCommand acceptRegisteredItemCommand, CancellationToken cancellationToken);
}