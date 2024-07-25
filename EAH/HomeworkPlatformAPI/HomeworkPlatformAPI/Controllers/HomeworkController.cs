using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Models;
using HomeworkPlatformAPI.Services.Abstaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        private readonly IWebHostEnvironment _env;

        public HomeworksController(IHomeworkService homeworkService, IWebHostEnvironment env)
        {
            _homeworkService = homeworkService;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<List<HomeworkResponseDTO>>> GetHomeworks()
        {
            return await _homeworkService.GetHomeworksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HomeworkResponseDTO>> GetHomeworkById(int id)
        {
            return await _homeworkService.GetHomeworkByIdAsync(id);
        }

        [HttpGet("author")]
        public async Task<ActionResult<List<HomeworkResponseDTO>>> GetHomeworksByAuthor(string author)
        {
            return await _homeworkService.GetHomeworksByAuthorAsync(author);
        }

        [HttpPost]
        public async Task<ActionResult> AddHomework(HomeworkRequestDTO homework)
        {
            await _homeworkService.AddHomeworkAsync(homework);
            return CreatedAtAction(nameof(GetHomeworkById), new { id = homework.Id }, homework);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHomework(int id)
        {
            await _homeworkService.DeleteHomeworkAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHomework(HomeworkRequestDTO homework)
        {
            await _homeworkService.UpdateHomeworkAsync(homework);
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadFile(IFormFile file, int assignmentId, string author)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var uploadsFolder = Path.Combine(_env.ContentRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileType = Path.GetExtension(file.FileName);

            var homeworkRequest = new HomeworkRequestDTO
            {
                Type = fileType,
                Name = file.FileName,
                Author = author,
                AssignmentId = assignmentId,
                FileName = file.FileName,
                FileContent = await ReadFileBytes(filePath)
            };

            await _homeworkService.AddHomeworkAsync(homeworkRequest);

            return CreatedAtAction(nameof(GetHomeworkById), new { id = homeworkRequest.Id }, homeworkRequest);
        }

        // Helper method to read file bytes
        private async Task<byte[]> ReadFileBytes(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
