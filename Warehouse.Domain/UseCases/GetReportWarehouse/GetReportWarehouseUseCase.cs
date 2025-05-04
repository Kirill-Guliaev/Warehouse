using FluentValidation;
using Warehouse.Domain.Authorization;
using Warehouse.Domain.UseCases.RegisterItem;

namespace Warehouse.Domain.UseCases.GetReportWarehouse;

public class GetReportWarehouseUseCase : IGetReportWarehouseUseCase
{
    private readonly IIntentionManager intentionManager;
    private readonly IGetReportWarehouseStorage storage;
    private readonly IIdentityProvider identityProvider;

    public GetReportWarehouseUseCase(
        IIntentionManager intentionManager,
        IGetReportWarehouseStorage storage,
        IIdentityProvider identityProvider)
    {
        this.intentionManager = intentionManager;
        this.storage = storage;
        this.identityProvider = identityProvider;
    }

    public Task ExecuteAsync(GetReportWarehouseCommand getReportWarehouseCommand, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
