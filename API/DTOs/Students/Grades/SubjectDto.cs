namespace API.DTOs;

public class SubjectDto
{
    public string SubjectName { get; set; }
    
    public string SubjectSymbol { get; set; }
    
    public int EctsPoints { get; set; }
    
    public bool FinalExam { get; set; }

    public string FacultyName { get; set; }
}