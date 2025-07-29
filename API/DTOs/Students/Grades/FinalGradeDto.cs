namespace API.DTOs;

public class FinalGradeDto
{
    public decimal FinalGrade { get; set; }
    
    public CourseDto Course { get; set; }
    
    public IEnumerable<GradeComponentDto> PartialGrades { get; set; }
}