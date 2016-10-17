using AutoMapper;
using SICO.Domain.Main.Sizes;

namespace SICO.Application.Main.Sizes.DtoAdapters
{
    public class UpdateSizeProfile:Profile
    {
        public UpdateSizeProfile()
        {
            CreateMap<UpdateSizeDto, Size>();
            CreateMap<Size, UpdateSizeDto>();
        }
    }
}
