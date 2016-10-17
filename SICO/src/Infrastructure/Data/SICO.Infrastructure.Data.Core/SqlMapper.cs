using System;
using System.Collections.Generic;
using System.Data;

namespace SICO.Infrastructure.Data.Core
{
    internal static class SqlMapper
    {
        private static Dictionary<Type, DbType> TypeToDbType
        {
            get
            {
                return new Dictionary<Type, DbType>() {
                    {typeof(Byte), DbType.Byte},
                    {typeof(SByte), DbType.SByte},
                    {typeof(Int16), DbType.Int16},
                    {typeof(UInt16), DbType.UInt16},
                    {typeof(Int32), DbType.Int32},
                    {typeof(UInt32), DbType.UInt32},
                    {typeof(Int64), DbType.Int64},
                    {typeof(UInt64), DbType.UInt64},
                    {typeof(Single), DbType.Single},
                    {typeof(Double), DbType.Double},
                    {typeof(Decimal), DbType.Decimal},
                    {typeof(Boolean), DbType.Boolean},
                    {typeof(String), DbType.String},
                    {typeof(Char), DbType.StringFixedLength},
                    {typeof(Guid), DbType.Guid},
                    {typeof(DateTime), DbType.DateTime},
                    {typeof(DateTimeOffset), DbType.DateTimeOffset},
                    {typeof(Byte[]), DbType.Binary},
                    {typeof(Byte?), DbType.Byte},
                    {typeof(SByte?), DbType.SByte},
                    {typeof(Int16?), DbType.Int16},
                    {typeof(UInt16?), DbType.UInt16},
                    {typeof(Int32?), DbType.Int32},
                    {typeof(UInt32?), DbType.UInt32},
                    {typeof(Int64?), DbType.Int64},
                    {typeof(UInt64?), DbType.UInt64},
                    {typeof(Single?), DbType.Single},
                    {typeof(Double?), DbType.Double},
                    {typeof(Decimal?), DbType.Decimal},
                    {typeof(Boolean?), DbType.Boolean},
                    {typeof(Char?), DbType.StringFixedLength},
                    {typeof(Guid?), DbType.Guid},
                    {typeof(DateTime?), DbType.DateTime},
                    {typeof(DateTimeOffset?), DbType.DateTimeOffset}
                };
            }
        }
        public static DbType ToDbType(this Type type)
        {
            DbType dbType;
            if (TypeToDbType.TryGetValue(type, out dbType))
            {
                return dbType;
            }
            throw new ArgumentOutOfRangeException("type", type, "Cannot map the Type to DbType");
        }
    }
}
