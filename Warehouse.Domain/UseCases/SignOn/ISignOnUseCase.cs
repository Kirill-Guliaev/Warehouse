using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.UseCases.SignOn;

public interface ISignOnUseCase
{
    public Task<IIdentity> ExecuteAsync(SignOnCommand command, CancellationToken cancellationToken);
}