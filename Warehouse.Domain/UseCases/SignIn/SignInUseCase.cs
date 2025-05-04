using System.ComponentModel.DataAnnotations;
using Warehouse.Domain.Authentication;

namespace Warehouse.Domain.UseCases.SignIn;

public class SignInUseCase : ISignInUseCase
{
    private readonly ISignInStorage signInStorage;

    public SignInUseCase(ISignInStorage signInStorage)
    {
        this.signInStorage = signInStorage;
    }

    public async Task<IIdentity> ExecuteAsync(SignInCommand command, CancellationToken cancellationToken)
    {
        return await signInStorage.FindUserAsync(command.Login, cancellationToken) ?? throw new ValidationException("User not found");
    }
}
