using Warehouse.Domain.Models;
using Warehouse.Storage.Entities;

namespace Warehouse.Storage.Mapper;
internal static class MapperExtensions
{
    internal static User ToUser(this Person person)
    {
        return new User(person.PersonId);
    }

    internal static Domain.Models.Item ToItem(this Entities.Item item)
    {
        return new Domain.Models.Item(item.ItemId, item.Name, item.Size, item.WarehouseId, item.ArrivedAt);
    }

    internal static Domain.Models.Warehouse ToWarehouse(this Entities.Warehouse item, int freeSize)
    {
        return new Domain.Models.Warehouse(item.WarehouseId, item.PriceForUnit, item.StorageVolume, FreeSize: freeSize);
    }


}
