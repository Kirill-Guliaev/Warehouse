using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Wearhouse
{
    [Key]
    public Guid WearhouseId { get; set; }

    public int StorageVolume { get; set; }

    public Guid OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner{ get; set; }

    [InverseProperty(nameof(Item.Wearhouse))]
    public ICollection<Item> Items { get; set; }
}
