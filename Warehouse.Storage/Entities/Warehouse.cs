using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Warehouse
{
    [Key]
    public Guid WarehouseId { get; set; }

    public int StorageVolume { get; set; }

    public int PriceForUnit { get; set; }

    public Guid OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner { get; set; } = null!;

    [InverseProperty(nameof(Item.Warehouse))]
    public ICollection<Item> Items { get; set; } = new List<Item>();
}

public static class WarehouseExtension
{
    public static int GetAvailableSpace(this Warehouse warehouse)
    {
        return warehouse.StorageVolume - warehouse.Items.Where(i => !i.CheckedOutAt.HasValue).Sum(i => i.Size);
    }
}