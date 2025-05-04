using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.UseCases.SignOn;

public interface ISignOnStorage
{
    public Task<Guid> CreateUserAsync(string login, CancellationToken cancellationToken);

    public Task<IIdentity?> FindUserAsync(string login, CancellationToken cancellationToken);
}
