using AutoMapper;
using SICO.Domain.Main.DetailSizeTypes;

namespace SICO.Application.Main.DetailsSizeType.DtoAdapters
{
    public class CreateDetailSizeTypeProfile: Profile
    {
        public CreateDetailSizeTypeProfile()
        {
            CreateMap<CreateDetailSizeTypeDto, DetailSizeType>();
            CreateMap<DetailSizeType, CreateDetailSizeTypeDto>();
        }
    }
}
