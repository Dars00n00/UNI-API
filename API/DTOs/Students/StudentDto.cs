using System.ComponentModel;
using API.DTOs.Students.Classes;

namespace API.DTOs.Students;

[DisplayName("Student")]
public class StudentDto
{
    public PersonDto Person { get; set; }
    public IEnumerable<FinalGradeDto> FinalGrades { get; set; }
    
}