using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;
using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.CheckoutItem;

public class CheckoutItemUseCase : ICheckoutItemUseCase
{
    private readonly IValidator<CheckoutItemCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly ICheckoutItemStorage storage;

    public CheckoutItemUseCase(
        IValidator<CheckoutItemCommand> validator,
        IIntentionManager intentionManager,
        ICheckoutItemStorage storage,
        IIdentityProvider identityProvider
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.storage = storage;
    }

    public async Task<Item> ExecuteAsync(CheckoutItemCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Work);
        return await storage.CheckoutItemAsync(command.ItemId, command.WarehouseId, cancellationToken);
    }
}
