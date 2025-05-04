namespace Warehouse.Domain.UseCases.GetReportWarehouse;

public interface IGetReportWarehouseStorage
{
    Task<(int PaidItems, int UnpaidItems, int ReservedPlaces)> ReportAsync(Guid warehouseId, CancellationToken cancellationToken);
}