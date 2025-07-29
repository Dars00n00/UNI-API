using API.DTOs.Students.Classes;

namespace API.DTOs.Students;

public class StudentDto
{
    public PersonDto Person { get; set; }
    
    public IEnumerable<FinalGradeDto> FinalGrades { get; set; }
    
    public IEnumerable<CourseDto> Courses { get; set; }
    
    public IEnumerable<ClassDto> Classes { get; set; }
}