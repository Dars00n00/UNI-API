using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Degree
{
    public int IdDegree { get; set; }

    public string DegreeName { get; set; } = null!;

    public virtual ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
}
