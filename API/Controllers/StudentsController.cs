using API.DTOs;
using API.DTOs.Students;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentsService _studentsService;

    public StudentsController(IStudentsService studentsService)
    {
        _studentsService = studentsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostNewStudentAsync([FromBody] NewStudentDto newStudentDto, CancellationToken cancellationToken)
    {
        await _studentsService.CreateStudentAsync(newStudentDto, cancellationToken);

        return Created();
    }

    [HttpPost]
    [Route("{studentId}/Grades/{CourseId}")]
    public async Task<IActionResult> PostNewStudentGradeComponentAsync([FromRoute] int studentId, [FromRoute] int courseId, 
        [FromBody] NewComponentGradeDto newComponentGradeDto, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudentsWithTheirGradesAsync(CancellationToken cancellationToken)
    {
        var result = await _studentsService
            .GetAllStudentsWithGradesAsync(cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [Route("{studentId}")]
    public async Task<IActionResult> GetStudentWithGradesByFilterAsync([FromRoute] int studentId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{studentId}/grades")]
    public async Task<IActionResult> GetStudentGradesAsync([FromRoute] int studentId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}/grades/{courseId}")]
    public async Task<IActionResult> GetStudentGradesByCourseId([FromRoute] int studentId, [FromRoute] int courseId)
    {
        throw new NotImplementedException();
    }
    
}
