using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Item
{
    [Key]
    public Guid ItemId { get; set; }

    public DateTime ArrivedAt { get; set; }

    public Guid OwnerId { get; set; }

    public Guid WearhouseId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public Person Owner { get; set; }

    [ForeignKey(nameof(WearhouseId))]
    public Wearhouse Wearhouse { get; set; }


}
