using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Lecturer
{
    public int IdLecturer { get; set; }

    public int IdDegree { get; set; }

    public int? IdSupervisor { get; set; }

    public int IdFaculty { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();

    public virtual ICollection<FinalGrade> FinalGrades { get; set; } = new List<FinalGrade>();

    public virtual Degree IdDegreeNavigation { get; set; } = null!;

    public virtual Faculty IdFacultyNavigation { get; set; } = null!;

    public virtual Person IdLecturerNavigation { get; set; } = null!;

    public virtual Lecturer? IdSupervisorNavigation { get; set; }

    public virtual ICollection<Lecturer> InverseIdSupervisorNavigation { get; set; } = new List<Lecturer>();
}
