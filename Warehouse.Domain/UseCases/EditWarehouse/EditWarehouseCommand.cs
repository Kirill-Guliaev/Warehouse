namespace Warehouse.Domain.UseCases.EditWarehouse;

public record EditWarehouseCommand(Guid WarehouseId, int? NewPrice, int? NewSize);