namespace Warehouse.Api.Models.Requests;

public record CheckoutItemRequest(Guid ItemId, Guid WarehouseId);