using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<PetitionStatus> PetitionStatuses { get; set; } = new List<PetitionStatus>();
}
