using System.Collections.Generic;

namespace SICO.Infrastructure.CrossCutting.ExceptionHandling
{
    public interface IInformationErrorException
    {
        IEnumerable<string> Messages { get; }
    }
}
