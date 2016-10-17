using AutoMapper;
using SICO.Domain.Main.SizeTypes;

namespace SICO.Application.Main.SizeTypes.DtoAdapters
{
    public class UpdateSizeTypeProfile: Profile
    {

        public UpdateSizeTypeProfile()
        {
            CreateMap<UpdateSizeTypeDto, SizeType>();
            CreateMap<SizeType, UpdateSizeTypeDto>();
        }
    }
}
