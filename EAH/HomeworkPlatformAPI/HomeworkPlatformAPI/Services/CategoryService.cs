using AutoMapper;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Interfaces;
using HomeworkPlatformAPI.Models;
using HomeworkPlatformAPI.Services.Abstaction;

namespace HomeworkPlatformAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task AddCategoryAsync(CategoryRequestDTO category)
        {
            var item = _mapper.Map<Category>(category);

            return _repository.AddAsync(item);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryResponseDTO>(item);
        }

        public async Task<List<CategoryResponseDTO>> GetCategoriesByNameAsync(string name)
        {
            var list = await _repository.GetAsync(item => item.Name == name);
            return _mapper.Map<List<CategoryResponseDTO>>(list);
        }

        public async Task<List<CategoryResponseDTO>> GetCategoriesAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryResponseDTO>>(list);
        }

        public Task UpdateCategoryAsync(CategoryRequestDTO category)
        {
            var item = _mapper.Map<Category>(category);
            return _repository.UpdateAsync(item);
        }
    }
}
