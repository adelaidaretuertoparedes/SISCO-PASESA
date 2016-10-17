using AutoMapper;
using SICO.Domain.Main.Classifications;

namespace SICO.Application.Main.Classifications.DtoAdapters
{
    public class ListClassificationProfile : Profile
    {
        public ListClassificationProfile()
        {
            CreateMap<Classification, ListClassificationDto>()
                .ForMember(d => d.ArticleGroupName, o => o.MapFrom(s => s.ArticleGroup.Name));
        }

    }
}

