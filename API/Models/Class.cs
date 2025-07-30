using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Class
{
    public int IdClass { get; set; }

    public int IdLecturer { get; set; }

    public int IdGroup { get; set; }

    public int IdCourse { get; set; }

    public int IdRoom { get; set; }

    public DateTime BeginTime { get; set; }

    public int DurationMinutes { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual Lecturer IdLecturerNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
