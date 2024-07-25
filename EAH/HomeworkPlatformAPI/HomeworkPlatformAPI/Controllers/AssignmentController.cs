using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Services.Abstaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AssignmentsController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AssignmentResponseDTO>>> GetAssignments()
    {
        return await _assignmentService.GetAssignmentsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentResponseDTO>> GetAssignmentById(int id)
    {
        return await _assignmentService.GetAssignmentByIdAsync(id);
    }

    [HttpGet("title")]
    public async Task<ActionResult<List<AssignmentResponseDTO>>> GetAssignmentsByTitle(string title)
    {
        return await _assignmentService.GetAssignmentsByTitleAsync(title);
    }

    [HttpPost]
    public async Task<ActionResult> AddAssignment(AssignmentRequestDTO assignment)
    {
        await _assignmentService.AddAssignmentAsync(assignment);
        return CreatedAtAction(nameof(GetAssignmentById), new { id = assignment.Id }, assignment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAssignment(int id)
    {
        await _assignmentService.DeleteAssignmentAsync(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAssignment(AssignmentRequestDTO assignment)
    {
        await _assignmentService.UpdateAssignmentAsync(assignment);
        return Ok();
    }
}