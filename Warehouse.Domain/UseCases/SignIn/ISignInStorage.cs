using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.UseCases.SignIn;

public interface ISignInStorage
{
    public Task<IIdentity?> FindUserAsync(string login, CancellationToken cancellationToken);
}
