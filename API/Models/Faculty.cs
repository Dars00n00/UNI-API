using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Faculty
{
    public int IdFaculty { get; set; }

    public string FacultyName { get; set; } = null!;

    public virtual ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
