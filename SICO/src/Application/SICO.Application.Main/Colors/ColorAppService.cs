using SICO.Application.Core;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using SICO.Domain.Main.Colors;
using SICO.Application.Main.Enumerations;
using System;
using SICO.Domain.Main.AvailableLegacyCodes;
using SICO.Infrastructure.CrossCutting.Common;

namespace SICO.Application.Main.Colors
{
    public class ColorAppService : ApplicationServiceBase, IColorAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Color> _repository;
        private readonly IRepositoryAsync<AvailableLegacyCode> _repositoryAvailableLegacyCode;
        private readonly IUserIdentity _userIdentity;

        public ColorAppService(IRepositoryAsync<Color> repository,
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
        public async Task ActivateAsync(int id, bool status)
        {
            CreateActivate(id, status);
            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task<ListColorDto> CreateAsync(CreateColorDto createColorDto)
        {
            var color = _mapper.Map<Color>(createColorDto);

            UnitOfWork.BeginTransaction();
            try
            {
                createColorDto.Name = (createColorDto.Name ?? "").TrimMiddle();
                var availableLegacyCode = await GetLastLegacyCodeColor();
                var availableNameColor = await _repository.GetAsync(x => x.Name == createColorDto.Name);

                if (availableNameColor == null)
                {                    
                    color.CreatorUser = _userIdentity.GetCurrentUserName();
                    color.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();
                    color.UpdaterIpAddress = _userIdentity.GetCurrentUserName();
                    color.UpdaterUser = _userIdentity.GetRemoteIpAddress();
                    color.LegacyCode = availableLegacyCode.Code;
                    color.Name = createColorDto.Name;
                    _repository.InsertGraph(color);
                    _repositoryAvailableLegacyCode.Delete(availableLegacyCode, false);

                    await UnitOfWork.SaveChangesAsync(true);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() {"Color ya fue registrado"});
                }

              UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            var colorDto = _mapper.Map<ListColorDto>(color);
         return colorDto;
        }
        public async Task DeleteAsync(int id)
        {
            _repository.Delete(new Color()
            {
                Id = id
            });
            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task<IEnumerable<ListColorDto>> GetAllAsync()
        {
            var colors = (await _repository.GetAllAsync());
            var listColorDto = _mapper.Map<IEnumerable<ListColorDto>>(colors);
            return listColorDto;
        }
        public async Task<PaginationDto<ListColorDto>> GetByCodeAsync(int page, int pageSize, string code = null, string name = null)
        {
            var Name = (name ?? "").TrimMiddle();
            var Code = (code ?? "").TrimMiddle();
            var colorsPaged = await _repository
                            .Query(x => ((Code == "" || x.Code.Contains(Code))
                                     &&  (Name == "" || x.Name.Contains(Name))))
                            .OrderByAsync(x => x.OrderByDescending(y => y.UpdateDate))
                            .SelectPageAsync(page, pageSize);

            var listColorsDto = _mapper.Map<IEnumerable<ListColorDto>>(colorsPaged);

            var listColorDtoPaged = new PaginationDto<ListColorDto>(listColorsDto,
                colorsPaged.PageSize,
                colorsPaged.PageNumber,
                colorsPaged.PageCount,
                colorsPaged.TotalItemCount);

            return listColorDtoPaged;
        }
        public async Task<IEnumerable<ListColorToExcelDto>> GetByCodeAsync(string code = null, string name = null)
        {
            var colors = await _repository
                            .Query(x => ((code == null || x.Code.Contains(code))
                                                    && (name == null || x.Name.Contains(name))))
                            .OrderByAsync(x => x.OrderByDescending(y => y.UpdateDate)).SelectAsync();

            var listColorsDto = _mapper.Map<IEnumerable<ListColorToExcelDto>>(colors);

            return listColorsDto;
        }
        public async Task<ListColorDto> GetByIdAsync(int id)
        {
            var color = await _repository.GetByIdAsync(id);
            var colorDto = _mapper.Map<ListColorDto>(color);
            return colorDto;          
        }
        public async Task UpdateAsync(UpdateColorDto updateColorDto)
        {
            UnitOfWork.BeginTransaction();
            try
            {
                updateColorDto.Name = (updateColorDto.Name??"").TrimMiddle();
                var availableNameColor = await _repository.GetAsync(x => x.Name == updateColorDto.Name && x.Id != updateColorDto.Id);

                if (availableNameColor == null)
                {
                    UpdateFromDto(updateColorDto);
                    await UnitOfWork.SaveChangesAsync(true);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "Color ya fue registrado" });
                }

                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }
        private void CreateActivate(int id, bool status)
        {
            _repository.Update(new Color()
            {
                Id = id,
                Status = status,
                UpdaterUser = _userIdentity.GetCurrentUserName(),
                UpdaterIpAddress = _userIdentity.GetRemoteIpAddress()
            }, x => x.Status);
        }
        private async Task<AvailableLegacyCode> GetLastLegacyCodeColor()
        {
            var availableLegacyCode = await _repositoryAvailableLegacyCode.GetAsync(x => x.TypeId == (int)LegacyCodeType.Color);
            if (availableLegacyCode == null)
            {
                throw new ApplicationValidationErrorsException(new List<string>() { "No existen código dispobibles para Color" });
            }
            return availableLegacyCode;
        }
        private void UpdateFromDto(UpdateColorDto updateColorDto)
        {
            var color = _mapper.Map<Color>(updateColorDto);
            color.UpdaterIpAddress = _userIdentity.GetCurrentUserName();
            color.UpdaterUser = _userIdentity.GetRemoteIpAddress();
            color.Name = updateColorDto.Name;
            _repository.Update(color,  x => x.Name);
        }
    }
}
