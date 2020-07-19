using System;

namespace Elthlead.Injection
{
    public struct MagicDataId : IEquatable<MagicDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Id { get; }
        public String Property { get; }

        public MagicDataId(Int32 id, String property)
        {
            Id = id;
            Property = property;
        }

        public static Boolean TryParse(String key, out MagicDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length != 2)
            {
                value = default;
                return false;
            }

            if (!array[0].StartsWith("Magic"))
            {
                value = default;
                return false;
            }

            key = array[0].Substring("Magic".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            String property = array[1];

            value = new MagicDataId(index, property);
            return true;
        }

        public static MagicDataId Parse(String key)
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

        public Boolean Equals(MagicDataId other) => Id == other.Id && Property == other.Property;
        public override Boolean Equals(Object obj) => obj is MagicDataId other && Equals(other);
        public static Boolean operator ==(MagicDataId left, MagicDataId right) => left.Equals(right);
        public static Boolean operator !=(MagicDataId left, MagicDataId right) => !left.Equals(right);
        public override String ToString() => $"Magic{Id:D3}_{Property}";

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