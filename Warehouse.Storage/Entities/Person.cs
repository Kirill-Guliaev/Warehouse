﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Storage.Entities;

public class Person
{
    [Key]
    public Guid PersonId { get; set; }

    [MaxLength(50)]
    public string Login { get; set; } = null!;

    [InverseProperty(nameof(Item.Owner))]
    public ICollection<Item> Items { get; set; } = new List<Item>();

    [InverseProperty(nameof(Warehouse.Owner))]
    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
