using API.DTOs.Students;

namespace API.Services;

public interface IStudentsService
{
    public Task<IEnumerable<StudentDto>> GetAllStudentsWithGradesAsync(CancellationToken cancellationToken);
    
    public Task<StudentDto> GetStudentWithGradesByStudentFilter(CancellationToken cancellationToken);
    
    public Task<bool> CreateStudentAsync(NewStudentDto newStudentDto, CancellationToken cancellationToken);
    
}