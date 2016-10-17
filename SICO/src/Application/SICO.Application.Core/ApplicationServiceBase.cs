using SICO.Domain.Core.UnitOfWorks;

namespace SICO.Application.Core
{
    public abstract class ApplicationServiceBase
    {        
        private readonly IUnitOfWorkAsync _unitOfWork;

        protected ApplicationServiceBase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IUnitOfWorkAsync UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }
    }
}
