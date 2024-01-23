using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryViewDto>().ReverseMap();
        }
    }
}