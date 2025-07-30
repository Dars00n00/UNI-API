using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AdministrativeRole
{
    public int IdRole { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Clerk> IdClerks { get; set; } = new List<Clerk>();
}
