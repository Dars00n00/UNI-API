using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<Role> IdRoles { get; set; } = new List<Role>();
}
