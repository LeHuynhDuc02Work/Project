using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class PostTagMapProfile : Profile
    {
        public PostTagMapProfile()
        {
            CreateMap<PostTagMap, PostTagMapDto>().ReverseMap();
        }
    }
}