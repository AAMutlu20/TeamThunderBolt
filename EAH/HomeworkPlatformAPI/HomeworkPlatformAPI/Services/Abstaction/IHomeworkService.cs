using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Models;

namespace HomeworkPlatformAPI.Services.Abstaction
{
    public interface IHomeworkService
    {
        Task<List<HomeworkResponseDTO>> GetHomeworksAsync();
        Task<HomeworkResponseDTO> GetHomeworkByIdAsync(int id);
        Task<List<HomeworkResponseDTO>> GetHomeworksByAuthorAsync(string title);
        Task AddHomeworkAsync(HomeworkRequestDTO homework);
        Task DeleteHomeworkAsync(int id);
        Task UpdateHomeworkAsync(HomeworkRequestDTO homework);
    }
}
