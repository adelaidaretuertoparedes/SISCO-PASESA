using System;
using System.Collections.Generic;
using System.Reflection;

namespace SICO.Domain.Core
{
    public abstract class ValueObjectBase<T> : IEquatable<T>
        where T : ValueObjectBase<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            T other = obj as T;
            return Equals(other);
        }
        public override int GetHashCode()
        {
            var fields = GetFields();

            var startValue = 17;
            var multiplier = 59;

            var hashCode = startValue;
            foreach (var field in fields)
            {
                var value = field.GetValue(this);

                if (value!=null)
                {
                    hashCode = hashCode * multiplier + value.GetHashCode();
                }
            }
            return hashCode;
        }
        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();
            var fields = new List<FieldInfo>();                        

            while (t!=typeof(object))
            {
#if NET461
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
#else
                fields.AddRange(t.GetTypeInfo().DeclaredFields);
#endif
                t = t.GetTypeInfo().BaseType;
            }
            return fields;
        }
        public virtual bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }
            var t = GetType();
            var otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }
            var fields = GetFields();

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {

            if (Equals(null, x))
            {
                return true;
            }

            return x.Equals(y);
        }

        public static bool operator !=(ValueObjectBase<T> x, ValueObjectBase<T> y)
        {
            return !(x == y);
        }
    }
}
