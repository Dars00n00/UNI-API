using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Petition
{
    public int IdPetition { get; set; }

    public string Content { get; set; } = null!;

    public DateTime FilingDatetime { get; set; }

    public DateTime? DecisionDatetime { get; set; }

    public string? DecisionDetails { get; set; }

    public int IdClerk { get; set; }

    public int IdStudent { get; set; }

    public virtual Clerk IdClerkNavigation { get; set; } = null!;

    public virtual Student IdStudentNavigation { get; set; } = null!;

    public virtual ICollection<PetitionStatus> PetitionStatuses { get; set; } = new List<PetitionStatus>();
}
