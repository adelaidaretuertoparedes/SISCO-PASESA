using SICO.Application.Core;
using SICO.Domain.Main.SizeTypes;
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
using SICO.Domain.Main.DetailSizeTypes;
using SICO.Domain.Core;

namespace SICO.Application.Main.SizeTypes
{
    public class SizeTypeAppService : ApplicationServiceBase, ISizeTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<SizeType> _repository;
        private readonly IRepositoryAsync<Domain.Main.Sizes.Size> _repositorySize;
        private readonly IRepositoryAsync<AvailableLegacyCode> _repositoryAvailableLegacyCode;
        private readonly IRepositoryAsync<DetailSizeType> _repositoryDetailSizeType;
        private readonly IUserIdentity _userIdentity;

        public SizeTypeAppService(IRepositoryAsync<SizeType> repository,
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper,
            IUserIdentity userIdentity,
            IRepositoryAsync<Domain.Main.Sizes.Size> repositorySize,
            IRepositoryAsync<DetailSizeType> repositoryDetailSizeType,
            IRepositoryAsync<AvailableLegacyCode> repositoryAvailableLegacyCode) : base(unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _userIdentity = userIdentity;
            _repositorySize = repositorySize;
            _repositoryDetailSizeType = repositoryDetailSizeType;
            _repositoryAvailableLegacyCode = repositoryAvailableLegacyCode;
        }

        public async Task<ListSizeTypeDto> CreateAsync(CreateSizeTypeDto createSizeTypeDto)
        {

            createSizeTypeDto.Name = createSizeTypeDto.Name.Trim();
            createSizeTypeDto.Description = string.IsNullOrEmpty(createSizeTypeDto.Description) ? null : createSizeTypeDto.Description.Trim();

            var sizetype = _mapper.Map<SizeType>(createSizeTypeDto);

            UnitOfWork.BeginTransaction();

            try
            {
                var availableLegacyCode = await GetLastLegacyCodeSizeType();
                var availableNameSizeType = await _repository.GetAsync(x => x.Name.ToLower() == createSizeTypeDto.Name.ToLower());

                if (availableNameSizeType == null)
                {
                    sizetype.CreatorUser = _userIdentity.GetCurrentUserName();
                    sizetype.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();
                    sizetype.UpdaterUser= sizetype.CreatorUser;
                    sizetype.UpdaterIpAddress = sizetype.CreatorIpAddress;
                    sizetype.LegacyCode = availableLegacyCode.Code;                    
                    _repository.InsertGraph(sizetype);
                    
                    // Elimina el Codigo Legacy del repositorio de disponibles
                    _repositoryAvailableLegacyCode.Delete(availableLegacyCode, false);

                    if (createSizeTypeDto.sizeIds != null) {
                        var detailSizeTypes = createSizeTypeDto.sizeIds.Select((s, i) => new DetailSizeType()
                        {
                            SizeId = s,
                            Order = i + 1,
                            CreatorUser = _userIdentity.GetCurrentUserName(),
                            CreatorIpAddress = _userIdentity.GetRemoteIpAddress()
                        });
                        _repositoryDetailSizeType.InsertGraphRange(detailSizeTypes);
                    }

                    // Guarda los cambios en las entidades
                    await UnitOfWork.SaveChangesAsync(true);

                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "Tipo de Talla ya fue registrado" });
                }
                UnitOfWork.Commit();

            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }

            var sizetypeDto = _mapper.Map<ListSizeTypeDto>(sizetype);
            return sizetypeDto;
        }
        public async Task Activate(int id, bool value)
        {            
            _repository.Update(new SizeType()
            {
                Id = id, 
                Status = value,
                UpdaterUser = _userIdentity.GetCurrentUserName(),
                UpdaterIpAddress = _userIdentity.GetRemoteIpAddress()
            }, x=> x.Status);
            
            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task DeleteAsync(int id)
        {
            _repository.Delete(new SizeType()
            {
                Id = id
            });

            await UnitOfWork.SaveChangesAsync(true);
        }
        public async Task<IEnumerable<ListSizeTypeDto>> GetAllAsync()
        {
            var sizetypes = await _repository.GetAsync(x => x.Status);
            var listSizeTypeDto = _mapper.Map<IEnumerable<ListSizeTypeDto>>(sizetypes);
            return listSizeTypeDto;
        }
        public async Task<ListSizeTypeDto> GetById(int id)
        {            
            var sizetype = (await _repository.GetAsync(x => x.Status && x.Id==id));
            var listSizeTypeDto = _mapper.Map<ListSizeTypeDto>(sizetype);
            return listSizeTypeDto;
        }
        public async Task<PaginationDto<ListSizeTypeDto>> GetByCodeNameSync(int page, int pageSize, string code = null, string name = null)
        {
           var sizetypePaged =  await _repository.Query(x=> ((code == null || x.Code.Contains(code)) 
                                                                    && (name == null || x.Name.Contains(name))))                                                 
                                                 .OrderByAsync(x => x.OrderByDescending(y => y.UpdateDate))
                                                 .SelectPageAsync(page, pageSize);

            var listSizeTypeDto = _mapper.Map<IEnumerable<ListSizeTypeDto>>(sizetypePaged);

            var listSizeTypeDtoPaged = new PaginationDto<ListSizeTypeDto>(listSizeTypeDto,
                 sizetypePaged.PageSize,
                sizetypePaged.PageNumber,
                sizetypePaged.PageCount,
                sizetypePaged.TotalItemCount);

            return listSizeTypeDtoPaged;
        }
        public void UpdateFromDto(UpdateSizeTypeDto updateSizeTypeDto)
        {
            updateSizeTypeDto.Description = string.IsNullOrEmpty(updateSizeTypeDto.Description) ? updateSizeTypeDto.Description : updateSizeTypeDto.Description.Trim();

            var sizetype = _mapper.Map<SizeType>(updateSizeTypeDto);
            sizetype.UpdaterUser = _userIdentity.GetCurrentUserName();
            sizetype.UpdaterIpAddress = _userIdentity.GetRemoteIpAddress();
            _repository.Update(sizetype, x => x.Name, x => x.Description);
        }
        public async Task UpdateAsync(UpdateSizeTypeDto updateSizeTypeDto)
        {
            UnitOfWork.BeginTransaction();
            try
            {
                updateSizeTypeDto.Name = updateSizeTypeDto.Name.Trim();

                var availableNameSizeType = await _repository.GetAsync(x => x.Name.ToLower() == updateSizeTypeDto.Name.ToLower() && x.Id != updateSizeTypeDto.Id);

                if (availableNameSizeType == null)
                {
                    UpdateFromDto(updateSizeTypeDto);

                    //Se eliminan lógicamente en la bd los registros eliminados por el usuario

                    if (updateSizeTypeDto.sizeDeleteIds != null && updateSizeTypeDto.sizeDeleteIds.Count>0)
                    {
                        await _repositoryDetailSizeType.BatchDeleteAsync(x=>updateSizeTypeDto.sizeDeleteIds.Contains(x.Id),new AuditEntity {
                            CreatorUser=_userIdentity.GetCurrentUserName(),
                            CreatorIpAddress=_userIdentity.GetRemoteIpAddress()
                        });                    
                    }
                    
                    if (updateSizeTypeDto.lstDetailSizeType != null && updateSizeTypeDto.lstDetailSizeType.Count>0)
                    {
                        //Actualizamos el orden de las tallas
                       var detailSizeTypes= updateSizeTypeDto.lstDetailSizeType.Select((d,i)=>new DetailSizeType {
                            Id=d.Id,
                            SizeId=d.SizeId,
                            SizeTypeId=d.SizeTypeId,
                            Order=i+1,
                            CreatorUser = _userIdentity.GetCurrentUserName(),
                            CreatorIpAddress = _userIdentity.GetRemoteIpAddress(),
                            UpdaterUser = _userIdentity.GetCurrentUserName(),
                            UpdaterIpAddress = _userIdentity.GetRemoteIpAddress()                            
                        }).ToList();

                        //Obtenemos los actualizados
                        var updatedDetailSizeTypes= detailSizeTypes.Where(d => d.Id > 0).Select(d=>d).ToList();
                        if (updatedDetailSizeTypes!=null && updatedDetailSizeTypes.Count>0) {
                            await _repositoryDetailSizeType.BulkUpdateAsync(updatedDetailSizeTypes);
                        }
                        //Agregamos los nuevos items
                        var addedDetailSizeTypes = detailSizeTypes.Where(d => d.Id == 0).Select(d => d).ToList();
                        if (addedDetailSizeTypes != null && addedDetailSizeTypes.Count > 0)
                        {
                            _repositoryDetailSizeType.InsertGraphRange(addedDetailSizeTypes);
                        }                        
                    }
                    await UnitOfWork.SaveChangesAsync(true);

                }
                else
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "Tipo Talla ya fue registrado" });
                }
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }
        private async Task<AvailableLegacyCode> GetLastLegacyCodeSizeType()
        {
            
                var availableLegacyCode = await _repositoryAvailableLegacyCode.GetAsync(x => x.TypeId == (int)LegacyCodeType.SizeType);
                if (availableLegacyCode == null)
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "No existen códigos disponibles para el Tipo de Talla" });
                }
                return availableLegacyCode;
        }

    }
}
