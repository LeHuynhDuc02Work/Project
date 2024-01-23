using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagViewDto>().ReverseMap();
        }
    }
}