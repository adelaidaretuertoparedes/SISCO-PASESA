using AutoMapper;
using SICO.Domain.Main.Sizes;

namespace SICO.Application.Main.Sizes.DctoAdapters
{
    public class CreateSizeProfile : Profile
    {

        public CreateSizeProfile()
        {
            CreateMap<CreateSizeDto, Size>();

            CreateMap<Size, CreateSizeDto>();
        }
    }
}
