using AutoMapper;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Interfaces;
using HomeworkPlatformAPI.Models;
using HomeworkPlatformAPI.Services.Abstaction;

namespace HomeworkPlatformAPI.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IRepository<Homework> _repository;
        private readonly IMapper _mapper;

        public HomeworkService(IRepository<Homework> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task AddHomeworkAsync(HomeworkRequestDTO homework)
        {
            var item = _mapper.Map<Homework>(homework);

            return _repository.AddAsync(item);
        }

        public Task DeleteHomeworkAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public async Task<HomeworkResponseDTO> GetHomeworkByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<HomeworkResponseDTO>(item);
        }

        public async Task<List<HomeworkResponseDTO>> GetHomeworksByAuthorAsync(string author)
        {
            var list = await _repository.GetAsync(item => item.Author == author);
            return _mapper.Map<List<HomeworkResponseDTO>>(list);
        }

        public async Task<List<HomeworkResponseDTO>> GetHomeworksAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<HomeworkResponseDTO>>(list);
        }

        public Task UpdateHomeworkAsync(HomeworkRequestDTO homework)
        {
            var item = _mapper.Map<Homework>(homework);
            return _repository.UpdateAsync(item);
        }
    }
}
