using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.UseCases.SignIn;

public interface ISignInUseCase
{
    public Task<IIdentity> ExecuteAsync(SignInCommand command, CancellationToken cancellationToken);
}
