using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Clerk
{
    public int IdClerk { get; set; }

    public virtual Person IdClerkNavigation { get; set; } = null!;

    public virtual ICollection<Petition> Petitions { get; set; } = new List<Petition>();
}
