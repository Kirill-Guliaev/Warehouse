
using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;
using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.ConfirmPay;

public class ConfirmPayItemUseCase : IConfirmPayItemUseCase
{
    private readonly IValidator<ConfirmPayItemCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IConfirmPayItemStorage storage;

    public ConfirmPayItemUseCase(
        IValidator<ConfirmPayItemCommand> validator,
        IIntentionManager intentionManager,
        IConfirmPayItemStorage storage,
        IIdentityProvider identityProvider
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.storage = storage;
    }

    public async Task<Item> ExecuteAsync(ConfirmPayItemCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Work);
        return await storage.ConfirmPayAsync(command.ItemId, command.WarehouseId, cancellationToken);
    }
}