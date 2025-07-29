using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Clerk
{
    public int IdClerk { get; set; }

    public int? IdSupervisor { get; set; }

    public virtual Person IdClerkNavigation { get; set; } = null!;

    public virtual Clerk? IdSupervisorNavigation { get; set; }

    public virtual ICollection<Clerk> InverseIdSupervisorNavigation { get; set; } = new List<Clerk>();

    public virtual ICollection<Petition> Petitions { get; set; } = new List<Petition>();

    public virtual ICollection<Role> IdRoles { get; set; } = new List<Role>();
}
