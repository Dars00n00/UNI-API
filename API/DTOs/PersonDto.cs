using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PersonDto
{
    
    [Required] [MaxLength(255)]
    public string FirstName { get; set; }
    
    [Required] 
    [MaxLength(255)]
    public string LastName { get; set; }
    
    [Required, EmailAddress] 
    public string Email { get; set; }
    
    [Required, RegularExpression("^[MF]$", ErrorMessage = "Gender can be either M or F")]
    public string Gender { get; set; }
    
    [Required]
    public DateOnly Birthdate { get; set; }
    
    [Required, MaxLength(100)]
    public string Nationality { get; set; }
    
    [Required]
    public AddressDto CorrespondenceAddress { get; set; }
    
    [Required]
    public AddressDto PermanentAddress { get; set; }

}