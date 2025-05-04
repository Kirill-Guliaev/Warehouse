namespace Warehouse.Domain.UseCases.EditWarehouse;

public interface IEditWarehouseUseCase
{
    Task<Models.Warehouse> ExecuteAsync(EditWarehouseCommand editWarehouseCommand, CancellationToken cancellationToken);
}
