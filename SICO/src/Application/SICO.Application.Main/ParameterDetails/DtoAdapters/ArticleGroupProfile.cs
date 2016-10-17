using AutoMapper;
using SICO.Application.Main.ParameterDetails.Dtos;
using SICO.Domain.Main.ArticleGroups;

namespace SICO.Application.Main.ParameterDetails.DtoAdapters
{
    public class ArticleGroupProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ArticleGroup, ArticleGroupDto>();
        }
    }
}
