using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;

namespace HomeworkPlatformAPI.Services.Abstaction
{
    public interface IAssignmentService
    {
        Task<List<AssignmentResponseDTO>> GetAssignmentsAsync();
        Task<AssignmentResponseDTO> GetAssignmentByIdAsync(int id);
        Task<List<AssignmentResponseDTO>> GetAssignmentsByTitleAsync(string title);
        Task AddAssignmentAsync(AssignmentRequestDTO assignment);
        Task DeleteAssignmentAsync(int id);
        Task UpdateAssignmentAsync(AssignmentRequestDTO assignment);
    }
}
