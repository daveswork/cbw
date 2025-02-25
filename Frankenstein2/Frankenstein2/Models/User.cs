using System;
using System.Collections.Generic;

namespace Frankenstein2.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
