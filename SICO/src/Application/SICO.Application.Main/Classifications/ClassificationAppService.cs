using SICO.Application.Core;
using SICO.Domain.Main.Classifications;
using SICO.Domain.Main.TableParameters;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SICO.Infrastructure.CrossCutting.Security;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using System;
using SICO.Infrastructure.Data.Main.Repositories;

namespace SICO.Application.Main.Classifications
{
    public class ClassificationAppService : ApplicationServiceBase, IClassificationAppService
    {
        private readonly IRepositoryAsync<Classification> _repository;
        private readonly IMapper _mapper;
        private readonly IUserIdentity _userIdentity;

        public object away { get; private set; }

        public ClassificationAppService(IRepositoryAsync<Classification> repository,
            IUnitOfWorkAsync unitOfWork,
            IMapper mapper,
            IUserIdentity userIdentity) : base(unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _userIdentity = userIdentity;
        }

        public async Task<ListClassificationDto> CreateAsync(CreateClassificationDto createClassificationDto)
        {
            ListClassificationDto classificationDto = null;
            UnitOfWork.BeginTransaction();
            try
            {
                var trd = await _repository.GetAsync(x => x.Name.Equals(createClassificationDto.Name.Trim()));

                if (trd != null)
                {
                    throw new ApplicationValidationErrorsException(new List<string>() { "Clasificación ya fue registrada" });
                }
                else
                {
                    var classification = _mapper.Map<Classification>(createClassificationDto);

                    classification.Name = classification.Name.Trim();
                    classification.CreatorUser = _userIdentity.GetCurrentUserName();
                    classification.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();
                    classification.Status = true;
                    _repository.InsertGraph(classification);

                    await UnitOfWork.SaveChangesAsync();
                    UnitOfWork.Commit();

                    classificationDto = _mapper.Map<ListClassificationDto>(classification);
                }
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
            return classificationDto;
        }

        public async Task<IEnumerable<ListClassificationDto>> GetAllAsync()
        {
            var classification = (await _repository.GetAllAsync()).Where(x => x.Status == true);
            var listClassificationDto = _mapper.Map<IEnumerable<ListClassificationDto>>(classification);
            return listClassificationDto;
        }

        public async Task<PaginationDto<ListClassificationDto>> GetAllClassificationAsync(int page, int pageSize, string name = null, string code = null, int? articleGroupCode = null)
        {
            var classificationPaged = await _repository.GetClassificationsAsync(page, pageSize, name, code, articleGroupCode);
            var listClassificationDto = _mapper.Map<IEnumerable<ListClassificationDto>>(classificationPaged);
            var listClassificationDtoPaged = new PaginationDto<ListClassificationDto>(listClassificationDto,
                classificationPaged.PageSize,
                classificationPaged.PageNumber,
                classificationPaged.PageCount,
                classificationPaged.TotalItemCount);

            return listClassificationDtoPaged;
        }

        public async Task UpdateAsync(UpdateClassificationDto updateClassificationDto)
        {
            UnitOfWork.BeginTransaction();
            try
            {
                var trd = await _repository.GetAsync(x => x.Name.Equals(updateClassificationDto.Name.Trim()) && x.Id == updateClassificationDto.Id);
                if (trd != null)
                {
                    UpdateClassification(trd, updateClassificationDto);
                    await UnitOfWork.SaveChangesAsync(true);
                    UnitOfWork.Commit();
                }
                else
                {
                    var trds = await _repository.GetAsync(x => x.Name.Equals(updateClassificationDto.Name.Trim()));
                    if (trds != null)
                    {
                        throw new ApplicationValidationErrorsException(new List<string>() { "Clasificación ya fue registrada" });
                    }
                    else
                    {
                        UpdateClassification(updateClassificationDto);
                        await UnitOfWork.SaveChangesAsync(true);
                        UnitOfWork.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                throw ex;
            }
        }

        private void UpdateClassification(Classification classification, UpdateClassificationDto updateClassificationDto)
        {
            classification.Name = updateClassificationDto.Name.Trim();
            classification.ArticleGroupCode = updateClassificationDto.ArticleGroupCode;
            classification.UpdaterUser = _userIdentity.GetCurrentUserName();
            classification.UpdaterIpAddress = _userIdentity.GetRemoteIpAddress();

            _repository.Update(classification,
                x => x.Name,
                x => x.ArticleGroupCode,
                x => x.UpdaterUser,
                x => x.UpdaterIpAddress,
                x => x.UpdateDate);
        }

        private void UpdateClassification(UpdateClassificationDto updateClassificationDto)
        {
            var classification = _mapper.Map<Classification>(updateClassificationDto);

            classification.Name = updateClassificationDto.Name.Trim();
            classification.ArticleGroupCode = updateClassificationDto.ArticleGroupCode;
            classification.CreatorUser = _userIdentity.GetCurrentUserName();
            classification.CreatorIpAddress = _userIdentity.GetRemoteIpAddress();

            _repository.Update(classification,
                x => x.Name,
                x => x.ArticleGroupCode,
                x => x.UpdaterUser,
                x => x.UpdaterIpAddress,
                x => x.UpdateDate);
        }

        public async Task ActiveAsync(int id, bool status)
        {
            _repository.Update(new Classification()
            {
                Id = id,
                Status = status,
                UpdaterUser = _userIdentity.GetCurrentUserName(),
                UpdaterIpAddress = _userIdentity.GetRemoteIpAddress()
            }, x => x.Status);
            await UnitOfWork.SaveChangesAsync(true);
        }
    }
}
