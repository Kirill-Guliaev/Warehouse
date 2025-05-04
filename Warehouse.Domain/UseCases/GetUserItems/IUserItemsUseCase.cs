using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.GetUserItems;

public interface IUserItemsUseCase
{
    public Task<IEnumerable<Item>> ExecuteAsync(UserItemsCommand command, CancellationToken cancellationToken);
}