using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.Intentions;

namespace Warehouse.Domain.UseCases.GetReportWarehouse;

public class GetReportWarehouseUseCase : IGetReportWarehouseUseCase
{
    private readonly IValidator<GetReportWarehouseCommand> validator;
    private readonly IIntentionManager intentionManager;
    private readonly IGetReportWarehouseStorage storage;

    public GetReportWarehouseUseCase(
        IValidator<GetReportWarehouseCommand> validator,
        IIntentionManager intentionManager,
        IGetReportWarehouseStorage storage
        )
    {
        this.validator = validator;
        this.intentionManager = intentionManager;
        this.storage = storage;
    }

    public async Task<(int PaidItems, int UnpaidItems, int ReservedPlaces)> ExecuteAsync(GetReportWarehouseCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);
        intentionManager.ThrowIfForbidden(WarehouseIntention.Work);
        return await storage.ReportAsync(command.WarehouseId, cancellationToken);
    }
}
