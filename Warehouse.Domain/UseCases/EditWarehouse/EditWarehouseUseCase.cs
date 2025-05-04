using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;

namespace Warehouse.Domain.UseCases.EditWarehouse;

public class EditWarehouseUseCase : IEditWarehouseUseCase
{
    private readonly IValidator<EditWarehouseCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IEditWarehouseStorage editWarehouseStorage;

    public EditWarehouseUseCase(
        IValidator<EditWarehouseCommand> validator,
        IIntentionManager intentionManager,
        IEditWarehouseStorage editWarehouseStorage
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.editWarehouseStorage = editWarehouseStorage;
    }

    public async Task<Models.Warehouse> ExecuteAsync(EditWarehouseCommand editWarehouseCommand, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(editWarehouseCommand, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Manage);
        var myWarehouse = await editWarehouseStorage.GetWarehouseAsync(editWarehouseCommand.WarehouseId, cancellationToken);
        var newPrice = editWarehouseCommand.NewPrice ?? myWarehouse.Price;
        if (editWarehouseCommand.NewSize is not null)
        {
            if (myWarehouse.Size - myWarehouse.FreeSize > editWarehouseCommand.NewSize)
            {
                throw new Exception("Warehouse is not enough empty");
            }
        }
        var newSize = editWarehouseCommand.NewSize ?? myWarehouse.Size;
        return await editWarehouseStorage.EditWarehouseAsync(editWarehouseCommand.WarehouseId, newPrice, newSize, cancellationToken);
    }
}
