using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostViewDto>().ReverseMap();
        }
    }
}