using AutoMapper;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Models;

namespace HomeworkPlatformAPI.Profiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<Assignment, AssignmentResponseDTO>();
            CreateMap<AssignmentRequestDTO, Assignment>();
        }
    }
}
