using System.Collections.Generic;
using System.Data;

namespace SICO.Domain.Core.Repositories
{
    public interface IDatabase
    {
        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
        IDataParameter CreateParameter<T>(string name, T value);
    }
}
