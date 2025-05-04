namespace Warehouse.Domain.UseCases.OpenWarehouse;

public interface IOpenWarhouseStorage
{
    Task<Models.Warehouse> OpenWarhouseAsync(Guid userId, int price, int size, CancellationToken cancellationToken);
}