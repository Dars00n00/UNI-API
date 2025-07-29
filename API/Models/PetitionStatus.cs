using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PetitionStatus
{
    public int IdPetition { get; set; }

    public int IdStatus { get; set; }

    public DateTime UpdateDatetime { get; set; }

    public virtual Petition IdPetitionNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
