namespace Warehouse.Domain.UseCases.CheckoutItem;

public record CheckoutItemCommand(Guid ItemId, Guid WarehouseId);
