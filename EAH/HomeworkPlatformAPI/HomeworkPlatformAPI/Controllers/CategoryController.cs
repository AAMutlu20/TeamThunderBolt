using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Services.Abstaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetCategories()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        [HttpGet("name")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetCategoriesByName(string name)
        {
            return await _categoryService.GetCategoriesByNameAsync(name);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryRequestDTO category)
        {
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryRequestDTO category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return Ok();
        }
    }
}
