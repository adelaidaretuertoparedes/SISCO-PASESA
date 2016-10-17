using SICO.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Data;
using System.Data.Common;

namespace SICO.Infrastructure.Data.Core
{
    internal class DatabaseWrapper : IDatabase
    {
        private readonly Database _database;
        public DatabaseWrapper(Database database)
        {
            _database = database;            
        }

        public IDataParameter CreateParameter<T>(string name, T value)
        {
            var param = CreateParameter(name);
            ConfigureParameter(param, name, typeof(T).ToDbType(), 0, ParameterDirection.Input, true, 0, 0, string.Empty, DataRowVersion.Default, value);
            return param;
        }

        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return _database.SqlQuery<T>(sql, parameters);
        }

        private void ConfigureParameter(DbParameter param,
                string name,
                DbType dbType,
                int size,
                ParameterDirection direction,
                bool nullable,
                byte precision,
                byte scale,
                string sourceColumn,
                DataRowVersion sourceVersion,
                object value)
        {
            param.DbType = dbType;
            param.Size = size;
            param.Value = value ?? DBNull.Value;
            param.Direction = direction;
            param.IsNullable = nullable;
            param.SourceColumn = sourceColumn;
            param.SourceVersion = sourceVersion;
        }

        private DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            var param = CreateParameter(name);
            ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            return param;
        }
        private DbParameter CreateParameter(string name)
        {
            var parameter = DbProviderFactories.GetFactory(_database.Connection).CreateParameter();
            parameter.ParameterName = name;
            return parameter;
        }
    }
}
