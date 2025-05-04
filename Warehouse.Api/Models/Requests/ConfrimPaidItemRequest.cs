namespace Warehouse.Api.Models.Requests;

public record ConfrimPaidItemRequest(Guid ItemId, Guid WarehouseId);