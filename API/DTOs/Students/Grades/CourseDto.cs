namespace API.DTOs;

public class CourseDto
{
    public string MainLecturerFullName { get; set; }
    
    public DateOnly CourseBeginDate { get; set; }
    
    public DateOnly CourseEndDate { get; set; }
    
    public SubjectDto Subject { get; set; }
}