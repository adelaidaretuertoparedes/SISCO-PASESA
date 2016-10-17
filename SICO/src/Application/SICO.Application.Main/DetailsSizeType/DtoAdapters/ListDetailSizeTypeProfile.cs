using AutoMapper;
using SICO.Domain.Main.DetailSizeTypes;
using SICO.Domain.Main.Sizes;

namespace SICO.Application.Main.DetailsSizeType.DtoAdapters
{
    public class ListDetailSizeTypeProfile: Profile
    {
        public ListDetailSizeTypeProfile()
        {
            CreateMap<ListDetailSizeTypeDto, DetailSizeType>();
            CreateMap<DetailSizeType, ListDetailSizeTypeDto>();

            CreateMap<ListDetailSizeTypeDto, Size>()
                 .ForMember(d => d.Name, o => o.MapFrom(s => s.SizeName));
        }
    }
}
