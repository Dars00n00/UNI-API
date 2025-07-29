using System;
using System.Collections.Generic;

namespace API.Models;

public partial class GradeComponent
{
    public int IdGradeComponent { get; set; }

    public int IdFinalGrade { get; set; }

    public int IdGradeType { get; set; }

    public decimal Grade { get; set; }

    public virtual FinalGrade IdFinalGradeNavigation { get; set; } = null!;

    public virtual GradeType IdGradeTypeNavigation { get; set; } = null!;
}
