using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
