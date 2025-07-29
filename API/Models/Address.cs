using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Address
{
    public int IdAddress { get; set; }

    public string StreetName { get; set; } = null!;

    public string BuildingNumber { get; set; } = null!;

    public string? ApartmentNumber { get; set; }

    public string PostalCode { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public int IdCountry { get; set; }

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual ICollection<Person> PersonIdCorrespondenceAddressNavigations { get; set; } = new List<Person>();

    public virtual ICollection<Person> PersonIdPernamentAddressNavigations { get; set; } = new List<Person>();
}
