using AutoMapper;
using SICO.Domain.Main.Classifications;

namespace SICO.Application.Main.Classifications.DtoAdapters
{
    public class UpdateClassificationProfile : Profile
    {
        public UpdateClassificationProfile()
        {
            CreateMap<UpdateClassificationDto, Classification>();
            CreateMap<Classification, UpdateClassificationDto>();
        }            
    }
}
