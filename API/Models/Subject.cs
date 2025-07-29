using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Subject
{
    public int IdSubject { get; set; }

    public string SubjectName { get; set; } = null!;

    public string SubjectSymbol { get; set; } = null!;

    public int EctsPoints { get; set; }

    public bool FinalExam { get; set; }

    public int IdFaculty { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Faculty IdFacultyNavigation { get; set; } = null!;
}
