using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

[DisplayName("Address")]
public class AddressDto
{
    [Required, MaxLength(100)]
    public string StreetName { get; set; }
        
    [Required, MaxLength(10)]
    public string BuildingNumber { get; set; }
        
    [Required, MaxLength(10)]
    public string? ApartmentNumber { get; set; }
        
    [Required, StringLength(6), 
     RegularExpression("^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Postal code in Polish format XX-XXX")]
    public string PostalCode { get; set; }
        
    [Required, MaxLength(100)]
    public string CityName { get; set; }

    [Required] 
    public int IdCountry { get; set; }
}
