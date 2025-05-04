using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.UnpaidItems;

public interface IUnpaidItemsUseCase
{
    Task<IEnumerable<UnpaidItem>> ExecuteAsync(UnpaidItemsCommand unpaidItemsCommand, CancellationToken cancellationToken);
}
