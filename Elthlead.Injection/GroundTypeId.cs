using System;

namespace Elthlead.Injection
{
    public struct GroundTypeId : IEquatable<GroundTypeId>
    {
        public Int32 Id { get; }

        public GroundTypeId(Int32 id)
        {
            Id = id;
        }

        public static Boolean TryParse(String key, out GroundTypeId value)
        {
            if (!key.StartsWith("GroundType"))
            {
                value = default;
                return false;
            }

            key = key.Substring("GroundType".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            value = new GroundTypeId(index);
            return true;
        }

        public static GroundTypeId Parse(String key)
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

        public override Int32 GetHashCode() => Id;
        public Boolean Equals(GroundTypeId other) => Id == other.Id;
        public override Boolean Equals(Object obj) => obj is GroundTypeId other && Equals(other);
        public static Boolean operator ==(GroundTypeId left, GroundTypeId right) => left.Equals(right);
        public static Boolean operator !=(GroundTypeId left, GroundTypeId right) => !left.Equals(right);
        public override String ToString() => $"GroundType{Id:D3}";
    }
}