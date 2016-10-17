using SICO.Application.Core;
using SICO.Domain.Main.Trademarks;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using System.Linq;
using SICO.Application.Main.Enumerations;
using System;
using SICO.Domain.Main.AvailableLegacyCodes;
using SICO.Infrastructure.CrossCutting.Common;

namespace SICO.Application.Main.Trademarks
{
    public class TrademarkAppService : ApplicationServiceBase, ITrademarkAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Trademark> _repository;
        private readonly IRepositoryAsync<AvailableLegacyCode> _repositoryAvailableLegacyCode;
        private readonly IUserIdentity _userIdentity;
        public TrademarkAppService(IRepositoryAsync<Trademark> repository,
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper,
            IUserIdentity userIdentity,
            IRepositoryAsync<AvailableLegacyCode> repositoryAvailableLegacyCode) : base(unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _userIdentity = userIdentity;
            _repositoryAvailableLegacyCode = repositoryAvailableLegacyCode;
        }

        public async Task<ListTrademarkDto> CreateAsync(CreateTrademarkDto createTrademarkDto)
        {
            ListTrademarkDto trademarksDto = null;
            UnitOfWork.BeginTransaction();
            try
            {
                string stringNameCreate = (createTrademarkDto.Name ?? "").TrimMiddle();
                var trd = await _repository.GetAsync(x => x.Name.Equals(stringNameCreate));
                if (trd != null)
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "La marca ya fue registrada" });
                }
                else
                {
                    var availableLegacyCode = await GetLastLegacyCodeTrademark();

                    //CreateTrademark(createTrademarkDto, availableLegacyCode.Code);
                    var trademark = _mapper.Map<Trademark>(createTrademarkDto);
                    trademark.Name = (createTrademarkDto.Name ?? "").TrimMiddle();
                    trademark.ShortName = (createTrademarkDto.ShortName ?? "").TrimMiddle();
                    trademark.Owner = (createTrademarkDto.Owner ?? "").TrimMiddle();
                    trademark.CreatorUser = _userIdentity.GetCurrentUserName();
                    trademark.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();
                    trademark.LegacyCode = availableLegacyCode.Code;
                    _repository.InsertGraph(trademark);

                    _repositoryAvailableLegacyCode.Delete(availableLegacyCode, false);

                    await UnitOfWork.SaveChangesAsync(true);
                    UnitOfWork.Commit();

                    trademarksDto = _mapper.Map<ListTrademarkDto>(trademark);
                }
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return trademarksDto;
        }

        public async Task DeleteAsync(int id)
        {
            _repository.Delete(new Trademark()
            {
                Id = id
            });
            await UnitOfWork.SaveChangesAsync(true);
        }

        public async Task<PaginationDto<ListTrademarkDto>> GetAsync(int page, int pageSize, string code = null, string name = null)
        {
            var trademarksPaged = await _repository
                 .Query(x => (x.Name.Contains(name) || name == null) &&
                             (x.Code.Contains(code) || code == null))
                 .OrderByAsync(x => x.OrderByDescending(y => y.UpdateDate))
                 .SelectPageAsync(page, pageSize);

            var listTrademarkDto = _mapper.Map<IEnumerable<ListTrademarkDto>>(trademarksPaged);

            var listTrademarkDtoPaged = new PaginationDto<ListTrademarkDto>(listTrademarkDto,
                 trademarksPaged.PageSize,
                trademarksPaged.PageNumber,
                trademarksPaged.PageCount,
                trademarksPaged.TotalItemCount);

            return listTrademarkDtoPaged;
        }

        public async Task<IEnumerable<ExcelTrademarkDto>> GetAsync(string code = null, string name = null)
        {
            var trademarksPaged = await _repository
                 .Query(x => (x.Name.Contains(name) || name == null) &&
                             (x.Code.Contains(code) || code == null))
                 .OrderByAsync(x => x.OrderByDescending(y => y.UpdateDate))
                 .SelectAsync();

            var excelTrademarkDto = _mapper.Map<IEnumerable<ExcelTrademarkDto>>(trademarksPaged);

            return excelTrademarkDto;
        }

        public async Task UpdateAsync(UpdateTrademarkDto updateTrademarkDto)
        {
            UnitOfWork.BeginTransaction();
            try
            {
                var Name = updateTrademarkDto.Name.TrimStart().TrimEnd();
                var availableNameColor = await _repository.GetAsync(x => x.Name == Name && x.Id != updateTrademarkDto.Id);

                if (availableNameColor == null)
                {
                    UpdateTrademark(updateTrademarkDto);
                    await UnitOfWork.SaveChangesAsync(true);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "La marca ya fue registrada" });
                }

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        private void UpdateTrademark(UpdateTrademarkDto updateTrademarkDto)
        {
            var trademark = _mapper.Map<Trademark>(updateTrademarkDto);
            trademark.Name = (updateTrademarkDto.Name ?? "").TrimMiddle();  
            trademark.ShortName = (updateTrademarkDto.ShortName ?? "").TrimMiddle();
            trademark.Owner = (updateTrademarkDto.Owner ?? "").TrimMiddle(); 
            trademark.UpdaterUser = _userIdentity.GetCurrentUserName();
            trademark.UpdaterIpAddress = _userIdentity.GetRemoteIpAddress();
            _repository.Update(trademark, x => x.Name, x => x.ShortName, x => x.Owner);
        }     

        public async Task ActivateAsync(int id, bool status)
        {
            _repository.Update(new Trademark()
            {
                Id = id,
                Status = status,
                UpdaterUser = _userIdentity.GetCurrentUserName(),
                UpdaterIpAddress = _userIdentity.GetRemoteIpAddress(),

            }, x => x.Status);

            await UnitOfWork.SaveChangesAsync(true);
        }
        private async Task<AvailableLegacyCode> GetLastLegacyCodeTrademark()
        {
            var availableLegacyCode = await _repositoryAvailableLegacyCode.GetAsync(x => x.TypeId == (int)LegacyCodeType.Trademark);
            if (availableLegacyCode == null)
            {
                throw new ApplicationValidationErrorsException(new List<string>() { "Código Legacy para tipo de marca no esta disponible, consulte adminsitardor del sistema." });
            }
            return availableLegacyCode;
        }
    }
}
