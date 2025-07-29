namespace API.DTOs;

public class GradeComponentDto
{
    public decimal Grade { get; set; }
    
    public string GradeType { get; set; }
    
    public DateOnly GradeDate { get; set; }
    
    public string LecturerFullName { get; set; }
}