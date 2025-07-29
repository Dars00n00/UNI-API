using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string CountryName { get; set; } = null!;

    public string NationalityName { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
