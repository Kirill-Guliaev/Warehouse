using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;

namespace Warehouse.Domain.UseCases.OpenWarehouse;

public class OpenWarehouseUseCase : IOpenWarehouseUseCase
{
    private readonly IValidator<OpenWarehouseCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IOpenWarhouseStorage openWarhouseStorage;
    private readonly IIdentityProvider identityProvider;

    public OpenWarehouseUseCase(
        IValidator<OpenWarehouseCommand> validator,
        IIntentionManager intentionManager,
        IOpenWarhouseStorage openWarhouseStorage,
        IIdentityProvider identityProvider)
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.openWarhouseStorage = openWarhouseStorage;
        this.identityProvider = identityProvider;
    }

    public async Task<Models.Warehouse> ExecuteAsync(OpenWarehouseCommand openWarehouseCommand, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(openWarehouseCommand, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Open);
        return await openWarhouseStorage.OpenWarhouseAsync(identityProvider.Current.UserId, openWarehouseCommand.Price, openWarehouseCommand.Size, cancellationToken);
        
    }
}
