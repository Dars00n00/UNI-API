using System;
using System.Collections.Generic;

namespace API.Models;

public partial class GradeType
{
    public int IdGradeType { get; set; }

    public string GradeType1 { get; set; } = null!;

    public virtual ICollection<GradeComponent> GradeComponents { get; set; } = new List<GradeComponent>();
}
