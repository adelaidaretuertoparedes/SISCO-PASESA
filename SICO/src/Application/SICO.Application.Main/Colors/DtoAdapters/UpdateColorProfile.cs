using AutoMapper;
using System;
using SICO.Domain.Main.Colors;

namespace SICO.Application.Main.Colors.DtoAdapters
{
    public class UpdateColorProfile : Profile
    {
        public UpdateColorProfile()
        {
            CreateMap<UpdateColorDto, Color>()
                 .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));                

            CreateMap<Color,UpdateColorDto>();
        }            
    }
}
