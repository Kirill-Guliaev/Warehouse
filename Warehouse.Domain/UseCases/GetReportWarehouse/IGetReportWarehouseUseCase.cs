
namespace Warehouse.Domain.UseCases.GetReportWarehouse;

public interface IGetReportWarehouseUseCase
{
    Task ExecuteAsync(GetReportWarehouseCommand getReportWarehouseCommand, CancellationToken cancellationToken);
}
