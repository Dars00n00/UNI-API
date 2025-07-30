using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Students;

[DisplayName("New student")]
public class NewStudentDto
{
    [Required]
    public PersonDto Person { get; set; }
    
    [Required]
    public DateOnly EnrollmentDate { get; set; }
}
