
namespace Warehouse.Domain.UseCases.GetReportWarehouse;

public interface IGetReportWarehouseUseCase
{
    Task<(int PaidItems, int UnpaidItems, int ReservedPlaces)> ExecuteAsync(GetReportWarehouseCommand getReportWarehouseCommand, CancellationToken cancellationToken);
}
