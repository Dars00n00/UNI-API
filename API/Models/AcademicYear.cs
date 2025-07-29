using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AcademicYear
{
    public int IdAcademicYear { get; set; }

    public DateOnly BeginDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<AcademicSemester> AcademicSemesters { get; set; } = new List<AcademicSemester>();
}
