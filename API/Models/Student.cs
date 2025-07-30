using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Student
{
    public int IdStudent { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public DateOnly? GraduationDate { get; set; }

    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();

    public virtual Person IdStudentNavigation { get; set; } = null!;

    public virtual ICollection<Petition> Petitions { get; set; } = new List<Petition>();

    public virtual ICollection<Group> IdGroups { get; set; } = new List<Group>();
}
