using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AcademicSemester
{
    public int IdAcademicSemester { get; set; }

    public int IdAcademicYear { get; set; }

    public DateOnly BeginDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual AcademicYear IdAcademicYearNavigation { get; set; } = null!;
}
