using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Students;

public class NewStudentDto
{
    [Required]
    public PersonDto PersonDto { get; set; }
    
    [Required]
    public DateOnly EnrollmentDate { get; set; }
}
