using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.RegisterItem;

public interface IRegisterItemUseCase
{
    public Task<Item> ExecuteAsync(RegisterItemCommand command, CancellationToken cancellationToken);
}
