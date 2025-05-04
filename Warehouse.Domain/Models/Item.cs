namespace Warehouse.Domain.Models;

public record Item(Guid Id, string Name, int Size, Guid WarhouseId, DateTimeOffset? ArrivedTime, DateTimeOffset? CheckoutAt);