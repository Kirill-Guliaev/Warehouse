using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Item
{
    [Key]
    public Guid ItemId { get; set; }

    public DateTime? ArrivedAt { get; set; } = null;

    [MaxLength(100)]
    public string Name { get; set; }

    public int Size { get; set; }

    public Guid OwnerId { get; set; }

    public Guid WarehouseId { get; set; }

    public DateTime? CheckedOutAt { get; set; }

    public bool IsPaid { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner { get; set; } = null!;

    [ForeignKey(nameof(WarehouseId))]
    public Warehouse Warehouse { get; set; } = null!;


}
