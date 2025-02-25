using System;
using System.Collections.Generic;

namespace Frankenstein2.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Qty { get; set; }

    public string? ItemImage { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
