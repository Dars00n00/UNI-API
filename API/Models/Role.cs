using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<Clerk> IdClerks { get; set; } = new List<Clerk>();
}
