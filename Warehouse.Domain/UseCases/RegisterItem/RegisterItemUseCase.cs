using Warehouse.Domain.Models;
using FluentValidation;
using Warehouse.Domain.Authorization;

namespace Warehouse.Domain.UseCases.RegisterItem;

public class RegisterItemUseCase : IRegisterItemUseCase
{
    private readonly IValidator<RegisterItemCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IRegisterItemStorage registerItemStorage;
    private readonly IIdentityProvider identityProvider;

    public RegisterItemUseCase(
        IValidator<RegisterItemCommand> validator,
        IIntentionManager intentionManager,
        IRegisterItemStorage registerItemStorage,
        IIdentityProvider identityProvider)
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.registerItemStorage = registerItemStorage;
        this.identityProvider = identityProvider;
    }

    public async Task<Item> ExecuteAsync(RegisterItemCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(ItemIntention.Register);
        await registerItemStorage.ThrowIfWarehouseNotAvailable(command.WarehouseId, command.Size, cancellationToken);
        return await registerItemStorage.RegisterItemAsync(identityProvider.Current.UserId, command.Name, command.Size, command.WarehouseId, cancellationToken);
    }
}
