using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;
using Warehouse.Domain.Models;

namespace Warehouse.Domain.UseCases.AcceptRegisteredItem;

public class AcceptRegisteredItemUseCase : IAcceptRegisteredItemUseCase
{
    private readonly IValidator<AcceptRegisteredItemCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IAcceptRegisteredItemStorage storage;

    public AcceptRegisteredItemUseCase(
        IValidator<AcceptRegisteredItemCommand> validator,
        IIntentionManager intentionManager,
        IAcceptRegisteredItemStorage storage,
        IIdentityProvider identityProvider
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.storage = storage;
    }

    public async Task<Item> ExecuteAsync(AcceptRegisteredItemCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Work);
        return await storage.AcceptRegisteredItemAsync(command.Id, cancellationToken);
    }
}
