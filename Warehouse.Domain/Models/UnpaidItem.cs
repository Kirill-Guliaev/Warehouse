namespace Warehouse.Domain.Models;

public record UnpaidItem(Guid ItemId, Guid WarehouseId, int SumToPay);