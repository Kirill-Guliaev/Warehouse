namespace Warehouse.Api.Models.Responses;

public record SimpleWarehouseReport(int PaidItems, int UnpaidItems, int AvailablePlaces);