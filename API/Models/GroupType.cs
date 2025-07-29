using System;
using System.Collections.Generic;

namespace API.Models;

public partial class GroupType
{
    public int IdGroupType { get; set; }

    public string GroupType1 { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
