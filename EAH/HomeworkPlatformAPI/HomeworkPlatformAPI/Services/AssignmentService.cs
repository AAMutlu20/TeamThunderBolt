using AutoMapper;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Interfaces;
using HomeworkPlatformAPI.Models;
using HomeworkPlatformAPI.Services.Abstaction;

namespace HomeworkPlatformAPI.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> _repository;
        private readonly IMapper _mapper;

        public AssignmentService(IRepository<Assignment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task AddAssignmentAsync(AssignmentRequestDTO assignment)
        {
            var item = _mapper.Map<Assignment>(assignment);

            return _repository.AddAsync(item);
        }

        public Task DeleteAssignmentAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }

        public async Task<AssignmentResponseDTO> GetAssignmentByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<AssignmentResponseDTO>(item);
        }

        public async Task<List<AssignmentResponseDTO>> GetAssignmentsByTitleAsync(string title)
        {
            var list = await _repository.GetAsync(item => item.Title == title);
            return _mapper.Map<List<AssignmentResponseDTO>>(list);
        }

        public async Task<List<AssignmentResponseDTO>> GetAssignmentsAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<AssignmentResponseDTO>>(list);
        }

        public Task UpdateAssignmentAsync(AssignmentRequestDTO assignment)
        {
            var item = _mapper.Map<Assignment>(assignment);
            return _repository.UpdateAsync(item);
        }
    }
}
