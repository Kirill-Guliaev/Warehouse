using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Item
{
    [Key]
    public Guid ItemId { get; set; }

    public DateTime ArrivedAt { get; set; }

    public Guid OwnerId { get; set; }

    public Guid WarehouseId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public Warehouse Warehouse { get; set; }


}
