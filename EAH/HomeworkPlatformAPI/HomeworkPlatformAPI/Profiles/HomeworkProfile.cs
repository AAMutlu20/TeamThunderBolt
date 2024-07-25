using AutoMapper;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.Models;

namespace HomeworkPlatformAPI.Profiles
{
    public class HomeworkProfile : Profile
    {
        public HomeworkProfile()
        {
            CreateMap<Homework, HomeworkResponseDTO>();
            CreateMap<HomeworkRequestDTO, Homework>();
        }   
    }
}
