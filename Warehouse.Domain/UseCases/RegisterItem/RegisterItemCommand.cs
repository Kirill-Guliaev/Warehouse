namespace Warehouse.Domain.UseCases.RegisterItem;

public record RegisterItemCommand(string Name, int Size, Guid WarehouseId);