namespace Warehouse.Domain.UseCases.EditWarehouse;

public interface IEditWarehouseStorage
{
    /// <summary>
    /// Редактирование данных склада
    /// </summary>
    /// <param name="warehouseId"></param>
    /// <param name="newPrice"></param>
    /// <param name="newSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Models.Warehouse> EditWarehouseAsync(Guid warehouseId, int newPrice, int newSize, CancellationToken cancellationToken);

    /// <summary>
    /// Получить актуальные данные склада. Не очень оптимальный метод
    /// </summary>
    /// <param name="warehouseId"></param>
    /// <returns></returns>
    Task<Models.Warehouse> GetWarehouseAsync(Guid warehouseId);
}