namespace Warehouse.Domain.UseCases.OpenWarehouse;

public interface IOpenWarehouseUseCase
{
    Task<Models.Warehouse> ExecuteAsync(OpenWarehouseCommand openWarehouseCommand, CancellationToken cancellationToken);
}
