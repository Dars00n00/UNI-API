using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Group
{
    public int IdGroup { get; set; }

    public int IdGroupType { get; set; }

    public int IdAcademicSemester { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual AcademicSemester IdAcademicSemesterNavigation { get; set; } = null!;

    public virtual GroupType IdGroupTypeNavigation { get; set; } = null!;

    public virtual ICollection<Student> IdStudents { get; set; } = new List<Student>();
}
