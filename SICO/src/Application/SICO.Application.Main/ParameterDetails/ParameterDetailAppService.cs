using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SICO.Application.Core;
using SICO.Domain.Core.Repositories;
using SICO.Domain.Core.UnitOfWorks;
using SICO.Domain.Main.ArticleGroups;
using SICO.Domain.Main.ParameterDetails;
using SICO.Application.Main.ParameterDetails.Dtos;

namespace SICO.Application.Main.ParameterDetails
{
    public class ParameterDetailAppService: ApplicationServiceBase,IParameterDetailAppService
    {
        private readonly IRepositoryAsync<ParameterDetail> _parameterDetailRepository;
        private readonly IMapper _mapper;        

        public ParameterDetailAppService(IRepositoryAsync<ParameterDetail> parameterDetailRepository,           
            IMapper mapper, 
            IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
            _parameterDetailRepository = parameterDetailRepository;
            _mapper = mapper;           
        }

        public async Task<IEnumerable<ArticleGroupDto>> GetArticleGroupsAsync()
        {          
            var articleGroups = await _parameterDetailRepository
                    .GetRepositoryAsync<ArticleGroup>()
                    .GetAllAsync();

            return _mapper.Map<IEnumerable<ArticleGroupDto>>(articleGroups);
        }
    }
}
