using System;

namespace Elthlead.Injection
{
    public struct ClassDataId : IEquatable<ClassDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Id { get; }
        public String Property { get; }

        public ClassDataId(Int32 id, String property)
        {
            Id = id;
            Property = property;
        }

        public static Boolean TryParse(String key, out ClassDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length != 2)
            {
                value = default;
                return false;
            }

            if (!array[0].StartsWith("Class"))
            {
                value = default;
                return false;
            }

            key = array[0].Substring("Class".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            String property = array[1];

            value = new ClassDataId(index, property);
            return true;
        }

        public static ClassDataId Parse(String key)
        {
            try
            {
                if (TryParse(key, out var result))
                    return result;

                throw new NotSupportedException(key);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(key, ex);
            }
        }

        public Boolean Equals(ClassDataId other) => Id == other.Id && Property == other.Property;
        public override Boolean Equals(Object obj) => obj is ClassDataId other && Equals(other);
        public static Boolean operator ==(ClassDataId left, ClassDataId right) => left.Equals(right);
        public static Boolean operator !=(ClassDataId left, ClassDataId right) => !left.Equals(right);
        public override String ToString() => $"Class{Id:D3}_{Property}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Property.GetHashCode();
                return hashCode;
            }
        }
    }
}