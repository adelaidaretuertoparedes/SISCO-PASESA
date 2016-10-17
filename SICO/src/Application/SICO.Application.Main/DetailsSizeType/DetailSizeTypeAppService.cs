using SICO.Application.Core;
using SICO.Domain.Main.DetailSizeTypes;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using System;
using System.Linq;

namespace SICO.Application.Main.DetailsSizeType
{
    public class DetailSizeTypeAppService: ApplicationServiceBase, IDetailSizeTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<DetailSizeType> _repository;
        private readonly IUserIdentity _userIdentity;

        public DetailSizeTypeAppService(
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper,
            IUserIdentity userIdentity,
            IRepositoryAsync<DetailSizeType> repositoryDetailSizeType) : base(unitOfWork)
        {
            _mapper = mapper;
            _userIdentity = userIdentity;
            _repository = repositoryDetailSizeType;
        }
        public async Task<IEnumerable<ListDetailSizeTypeDto>> GetBySizeTypeIdAsync(int idSizeType)
        {
            var details = await _repository.GetManyAsync(x => x.SizeTypeId == idSizeType);
            var listDetail = _mapper.Map<IEnumerable<ListDetailSizeTypeDto>>(details);
            return listDetail;
        }
        public async Task CreateAsync(CreateDetailSizeTypeDto createDetailSizeTypeDto)
        {

            UnitOfWork.BeginTransaction();

            try
            {
                    var detailsizetype = _mapper.Map<DetailSizeType>(createDetailSizeTypeDto);
                    _repository.InsertGraph(detailsizetype);

                    // Guarda los cambios en las entidades
                    await UnitOfWork.SaveChangesAsync(true);

                    UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }
        public async Task DeleteAsync(int idSize)
        {
           var details= await _repository.GetManyAsync(x => x.SizeTypeId == idSize);
            _repository//.Query(x => x.SizeTypeId == idSize)
                .DeleteRange(details,false);

            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task<IEnumerable<ListDetailSizeTypeDto>> GetSizesBySizeType(int idSizeType)
        {
            var sizes = await _repository
                              .Query(x => x.SizeTypeId == idSizeType && x.Status)
                              .IncludeAsync(x=> x.Size)
                              .OrderByAsync(x => x.OrderBy(y => y.Order)).SelectAsync();

            var listSizesDto = _mapper.Map<IEnumerable<ListDetailSizeTypeDto>>(sizes);

            return listSizesDto;
        }
    }
}
