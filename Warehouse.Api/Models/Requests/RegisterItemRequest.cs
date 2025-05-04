namespace Warehouse.Api.Models.Requests;

public record RegisterItemRequest(string Name, int Size, Guid WarehouseId);