using System;
using System.Collections.Generic;

namespace Frankenstein2.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public string? Date { get; set; }

    public int? Qty { get; set; }

    public double? SalePrice { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual User? User { get; set; }
}
