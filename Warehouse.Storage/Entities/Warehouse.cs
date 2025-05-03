using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Warehouse
{
    [Key]
    public Guid WarehouseId { get; set; }

    public int StorageVolume { get; set; }

    public Guid OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner{ get; set; }

    [InverseProperty(nameof(Item.Warehouse))]
    public ICollection<Item> Items { get; set; }
}
