using System;

namespace Elthlead.Injection
{
    public struct SkillDataId : IEquatable<SkillDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Id { get; }
        public String Property { get; }

        public SkillDataId(Int32 id, String property)
        {
            Id = id;
            Property = property;
        }

        public static Boolean TryParse(String key, out SkillDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length != 2)
            {
                value = default;
                return false;
            }

            if (!array[0].StartsWith("Skill"))
            {
                value = default;
                return false;
            }

            key = array[0].Substring("Skill".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            String property = array[1];

            value = new SkillDataId(index, property);
            return true;
        }

        public static SkillDataId Parse(String key)
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

        public Boolean Equals(SkillDataId other) => Id == other.Id && Property == other.Property;
        public override Boolean Equals(Object obj) => obj is SkillDataId other && Equals(other);
        public static Boolean operator ==(SkillDataId left, SkillDataId right) => left.Equals(right);
        public static Boolean operator !=(SkillDataId left, SkillDataId right) => !left.Equals(right);
        public override String ToString() => $"Skill{Id:D3}_{Property}";

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