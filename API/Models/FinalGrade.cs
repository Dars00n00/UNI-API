using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FinalGrade
{
    public int IdFinalGrade { get; set; }

    public int IdStudent { get; set; }

    public int IdCourse { get; set; }

    public int IdLecturer { get; set; }

    public decimal FinalGrade1 { get; set; }

    public virtual ICollection<GradeComponent> GradeComponents { get; set; } = new List<GradeComponent>();

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Lecturer IdLecturerNavigation { get; set; } = null!;

    public virtual Student IdStudentNavigation { get; set; } = null!;
}
