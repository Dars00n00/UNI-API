using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public int IdNationality { get; set; }

    public int IdCorrespondenceAddress { get; set; }

    public int IdPernamentAddress { get; set; }

    public virtual Clerk? Clerk { get; set; }

    public virtual Address IdCorrespondenceAddressNavigation { get; set; } = null!;

    public virtual Country IdNationalityNavigation { get; set; } = null!;

    public virtual Address IdPernamentAddressNavigation { get; set; } = null!;

    public virtual Lecturer? Lecturer { get; set; }

    public virtual Student? Student { get; set; }
}
