using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.UseCases.GetReportWarehouse;
using Warehouse.Storage.Entities;

namespace Warehouse.Storage.Storages;

public class GetReportWarehouseStorage : IGetReportWarehouseStorage
{
    private readonly WarehouseDbContext dbContext;

    public GetReportWarehouseStorage(WarehouseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<(int PaidItems, int UnpaidItems, int ReservedPlaces)> ReportAsync(Guid warehouseId, CancellationToken cancellationToken)
    {
        var warehouse = await dbContext.Warehouses
               .Include(w => w.Items)
               .FirstOrDefaultAsync(w => w.WarehouseId == warehouseId)
               ?? throw new Exception("Warehouse not found");

        return new(warehouse.Items.Count(i => i.IsPaid), warehouse.Items.Count(i => !i.IsPaid), warehouse.GetAvailableSpace());
    }
}
