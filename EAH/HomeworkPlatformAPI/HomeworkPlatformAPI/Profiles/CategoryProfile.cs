using AutoMapper;
using HomeworkPlatformAPI.DTOs.Requests;
using HomeworkPlatformAPI.DTOs.Responces;
using HomeworkPlatformAPI.Models;

namespace HomeworkPlatformAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryRequestDTO, Category>();
        }
    }
}
