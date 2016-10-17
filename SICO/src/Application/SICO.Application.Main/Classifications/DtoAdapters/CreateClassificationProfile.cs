using AutoMapper;
using SICO.Domain.Main.Classifications;
using System;

namespace SICO.Application.Main.Classifications.DtoAdapters
{
    public class CreateClassificationProfile : Profile
    {
        public CreateClassificationProfile()
        {
            CreateMap<CreateClassificationDto, Classification>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));

            CreateMap<Classification, CreateClassificationDto>();
        }
    }
}
