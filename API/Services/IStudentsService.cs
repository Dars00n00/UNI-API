using API.DTOs.Students;

namespace API.Services;

public interface IStudentsService
{
    public Task<IEnumerable<StudentDto>> GetAllStudentsAsync(CancellationToken cancellationToken);
    public Task<bool> CreateStudentAsync(NewStudentDto newStudentDto, CancellationToken cancellationToken);
    
    
}