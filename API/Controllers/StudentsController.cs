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

    [HttpGet]
    public async Task<IActionResult> GetAllStudentsAsync()
    {
        return Ok(" ");
    }

    [HttpGet]
    [Route("{studentId}")]
    public Task<IActionResult> GetStudentByIdAsync([FromRoute] int studentId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{studentId}/grades")]
    public Task<IActionResult> GetStudentGradesAsync([FromRoute] int studentId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}/grades/{courseId}")]
    public Task<IActionResult> GetStudentGradesByCourseId([FromRoute] int studentId, [FromRoute] int courseId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> PostNewStudentAsync([FromBody] NewStudentDto newStudentDto, CancellationToken cancellationToken)
    {
        var result = await _studentsService.CreateStudentAsync(newStudentDto, cancellationToken);

        return Created();
    }
    
}
