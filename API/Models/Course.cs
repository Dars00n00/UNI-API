using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Course
{
    public int IdCourse { get; set; }

    public int IdSubject { get; set; }

    public int IdMainLecturer { get; set; }

    public DateOnly BeginDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();

    public virtual Lecturer IdMainLecturerNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
