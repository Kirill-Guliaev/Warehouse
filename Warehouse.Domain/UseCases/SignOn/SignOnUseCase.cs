using System.ComponentModel.DataAnnotations;
using Warehouse.Domain.Authentication;
using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.SignOn;

public class SignOnUseCase : ISignOnUseCase
{
    private readonly ISignOnStorage storage;

    public SignOnUseCase(ISignOnStorage signInStorage)
    {
        this.storage = signInStorage;
    }

    public async Task<IIdentity> ExecuteAsync(SignOnCommand command, CancellationToken cancellationToken)
    {
        var user = await storage.FindUserAsync(command.Login, cancellationToken);
        if (user is not null)
        {
            throw new ValidationException("User not found");
        }
        var userId = await storage.CreateUserAsync(command.Login, cancellationToken);
        return new User(userId);
    }
}