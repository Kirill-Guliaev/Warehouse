namespace Warehouse.Domain.UseCases.ConfirmPay;

public record ConfirmPayItemCommand(Guid ItemId, Guid WarehouseId);