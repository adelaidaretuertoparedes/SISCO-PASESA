using AutoMapper;
using SICO.Domain.Main.Colors;

namespace SICO.Application.Main.Colors.DtoAdapters
{
    public class CreateColorProfile : Profile
    {
        public CreateColorProfile()
        {
            CreateMap<CreateColorDto, Color>();                

            CreateMap<Color,CreateColorDto>();
        }            
    }
}
