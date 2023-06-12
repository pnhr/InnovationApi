using AutoMapper;
using Innovation.Data.DbModels;
using Innovation.Data.Dtos;

namespace Innovation.Api.AutoMapperProfiles
{
    public class IdeaAutomapperProfile : Profile
    {
        public IdeaAutomapperProfile()
        {
            CreateMap<Idea, IdeaDTO>()
                .ForMember(dest => dest.IdeaName, opt => opt.MapFrom(src => src.IdeaName))
                .ForMember(dest => dest.IdeaRef, opt => opt.MapFrom(src => src.IdeaRef ?? ""))
                .ForMember(dest => dest.IdeaDescription, opt => opt.MapFrom(src => src.IdeaDescription));

            CreateMap<IdeaDTO, Idea>()
                .ForMember(dest => dest.IdeaName, opt => opt.MapFrom(src => src.IdeaName))
                .ForMember(dest => dest.IdeaRef, opt => opt.MapFrom(src => src.IdeaRef ?? ""))
                .ForMember(dest => dest.IdeaDescription, opt => opt.MapFrom(src => src.IdeaDescription));
        }
    }
}
