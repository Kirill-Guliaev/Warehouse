
namespace Warehouse.Domain.UseCases.ConfirmPay;

public interface IConfirmPayItemUseCase
{
    Task<Models.Item> ExecuteAsync(ConfirmPayItemCommand confirmPayItemCommand, CancellationToken cancellationToken);
}
