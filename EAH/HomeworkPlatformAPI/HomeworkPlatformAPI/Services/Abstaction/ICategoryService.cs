using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;

namespace HomeworkPlatformAPI.Services.Abstaction
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetCategoriesAsync();
        Task<CategoryResponseDTO> GetCategoryByIdAsync(int id);
        Task<List<CategoryResponseDTO>> GetCategoriesByNameAsync(string name);
        Task AddCategoryAsync(CategoryRequestDTO category);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(CategoryRequestDTO category);
    }
}
