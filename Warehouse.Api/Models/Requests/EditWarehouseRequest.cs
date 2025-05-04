namespace Warehouse.Api.Models.Requests;

public record EditWarehouseRequest(Guid WarehouseId, int? NewPrice, int? NewSize);