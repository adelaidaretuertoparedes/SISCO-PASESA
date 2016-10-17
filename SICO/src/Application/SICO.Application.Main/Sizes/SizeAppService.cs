using SICO.Application.Core;
using SICO.Domain.Main.Sizes;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using System.Linq;
using System;
using SICO.Application.Main.Enumerations;
using SICO.Domain.Main.AvailableLegacyCodes;

namespace SICO.Application.Main.Sizes
{
    public class SizeAppService : ApplicationServiceBase, ISizeAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Size> _repository;
        private readonly IRepositoryAsync<Domain.Main.SizeTypes.SizeType> _repositorySizeType;
        private readonly IRepositoryAsync<AvailableLegacyCode> _repositoryAvailableLegacyCode;
        private readonly IRepositoryAsync<Domain.Main.DetailSizeTypes.DetailSizeType> _repositoryDetailSizeType;
        private readonly IUserIdentity _userIdentity;

        public SizeAppService(IRepositoryAsync<Size> repository,
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper,
            IUserIdentity userIdentity,
            IRepositoryAsync<Domain.Main.SizeTypes.SizeType> repositorySizeType,
            IRepositoryAsync<Domain.Main.DetailSizeTypes.DetailSizeType> repositoryDetailSizeType,
            IRepositoryAsync<AvailableLegacyCode> repositoryAvailableLegacyCode) : base(unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _userIdentity = userIdentity;
            _repositorySizeType = repositorySizeType;
            _repositoryDetailSizeType = repositoryDetailSizeType;
            _repositoryAvailableLegacyCode = repositoryAvailableLegacyCode;
        }

        public async Task<ListSizeDto> CreateAsync(CreateSizeDto createSizeDto)
        {

            createSizeDto.Name = createSizeDto.Name.Trim();

            var size = _mapper.Map<Size>(createSizeDto);
            UnitOfWork.BeginTransaction();

            try
            {
                var availableLegacyCode = await GetLastLegacyCodeSize();
                var availableNameSize = await _repository.GetAsync(x => x.Name.ToLower() == createSizeDto.Name.ToLower());

                if (availableNameSize == null)
                {
                    size.CreatorUser = _userIdentity.GetCurrentUserName();
                    size.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();
                    size.UpdaterUser = size.CreatorUser;
                    size.UpdaterIpAddress = size.CreatorIpAddress;
                    size.LegacyCode = availableLegacyCode.Code;
                    _repository.InsertGraph(size);

                    // Elimina el Codigo Legacy del repositorio de disponibles
                    _repositoryAvailableLegacyCode.Delete(availableLegacyCode, false);

                    // Guarda los cambios en las entidades
                    await UnitOfWork.SaveChangesAsync(true);

                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "Talla ya fue registrada" });
                }
                UnitOfWork.Commit();

            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            var sizeDto = _mapper.Map<ListSizeDto>(size);
            return sizeDto;
        }
        public async Task DeleteAsync(int id)
        {
            _repository.Delete(new Size()
            {
                Id = id
            });
            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task DeleteBySizeTypeIdAsync(int idSizeType)
        {

            var sizes = (await _repository.GetAllAsync());
            var sizestypes = (await _repositorySizeType.GetAllAsync()).Where(x => x.Id == idSizeType);
            var detailssizetype = (await _repositoryDetailSizeType.GetAllAsync());

            var result = from s in sizes
                         join dst in detailssizetype on s.Id equals dst.SizeId
                         join st in sizestypes on dst.SizeTypeId equals st.Id
                         where s.Status && st.Id == idSizeType
                         select new ListSizeBySizeTypeDto()
                         {
                             Id = s.Id,
                             Name = s.Name
                         };

            //_repository.DeleteRange(result);

            //var listSize = _mapper.Map<IEnumerable<Size>>(result);
            foreach (var size in result)
            {
                _repository.Delete(size.Id);

            }
            await UnitOfWork.SaveChangesAsync();

        }
        public async Task<IEnumerable<ListSizeDto>> GetAllAsync()
        {
            var sizes = (await _repository.GetAllAsync()).Where(x => x.Status = true);
            var listSizeDto = _mapper.Map<IEnumerable<ListSizeDto>>(sizes);
            return listSizeDto;
        }
        public async Task<IEnumerable<ListSizeDto>> GetSizeAsync(int id)
        {
            var sizes = (await _repository.GetAllAsync()).Where(x => x.Status && x.Id.Equals(id));
            var listSizeDto = _mapper.Map<IEnumerable<ListSizeDto>>(sizes);
            return listSizeDto;
        }
        public async Task<PaginationDto<ListSizeDto>> GetByCodeNameSync(int page, int pageSize, string code = null, string name = null)
        {
            var sizePaged = await _repository
                 .Query(x =>
                        (
                        (code != null && name != null &&
                        x.Code.Contains(code) && x.Name.Contains(name) && x.Status)
                        ||
                        (code != null && name == null && x.Code.Contains(code) && x.Status)
                        ||
                        (code == null && name != null && x.Name.Contains(name) && x.Status)
                        ||
                        (code == null && name == null && x.Status)
                        ))
                 .OrderByAsync(x => x.OrderBy(y => y.Id))
                 .SelectPageAsync(page, pageSize);

            var listSizeDto = _mapper.Map<IEnumerable<ListSizeDto>>(sizePaged);

            var listSizeDtoPaged = new PaginationDto<ListSizeDto>(listSizeDto,
                 sizePaged.PageSize,
                sizePaged.PageNumber,
                sizePaged.PageCount,
                sizePaged.Count);

            return listSizeDtoPaged;
        }
        public async Task<IEnumerable<ListSizeDto>> GetByNameSync(string name = null)
        {
            var sizes = await _repository
                             .Query(x => x.Status && (name == null || x.Name.Contains(name)))
                             .OrderByAsync(x => x.OrderBy(y => y.Id)).SelectAsync();

            var listSizesDto = _mapper.Map<IEnumerable<ListSizeDto>>(sizes);

            return listSizesDto;
        }
        public void UpdateFromDto(UpdateSizeDto updateSizeDto)
        {
            updateSizeDto.Name = updateSizeDto.Name.Trim();

            var size = _mapper.Map<Size>(updateSizeDto);
            size.UpdaterUser = _userIdentity.GetCurrentUserName();
            size.UpdaterIpAddress = _userIdentity.GetRemoteIpAddress();
            _repository.Update(size, x => x.Name);
        }
        public async Task UpdateAsync(UpdateSizeDto updateSizeDto)
        {
            UpdateFromDto(updateSizeDto);
            await UnitOfWork.SaveChangesAsync(true);
        }
        private async Task<AvailableLegacyCode> GetLastLegacyCodeSize()
        {
            var availableLegacyCode = await _repositoryAvailableLegacyCode.GetAsync(x => x.TypeId==(int)LegacyCodeType.Size);
            if (availableLegacyCode == null)
            {
                throw new ApplicationValidationErrorsException(new List<string>() { "No existen códigos disponibles para la Talla" });
            }
            return availableLegacyCode;
        }
    }
}
