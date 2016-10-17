using AutoMapper;
using SICO.Domain.Main.SizeTypes;

namespace SICO.Application.Main.SizeTypes.DtoAdapters
{
    public class CreateSizeTypeProfile : Profile
    {
        public CreateSizeTypeProfile()
        {
            CreateMap<CreateSizeTypeDto, SizeType>();
            CreateMap<SizeType, CreateSizeTypeDto>();
        }

    }

}
