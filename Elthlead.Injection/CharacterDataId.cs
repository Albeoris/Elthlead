using System;

namespace Elthlead.Injection
{
    public struct CharacterDataId : IEquatable<CharacterDataId>
    {
        public Int32 Id { get; }

        public CharacterDataId(Int32 id)
        {
            Id = id;
        }

        public static Boolean TryParse(String key, out CharacterDataId value)
        {
            if (!key.StartsWith("Character"))
            {
                value = default;
                return false;
            }

            key = key.Substring("Character".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            value = new CharacterDataId(index);
            return true;
        }

        public static CharacterDataId Parse(String key)
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

        public Boolean Equals(CharacterDataId other) => Id == other.Id;
        public override Boolean Equals(Object obj) => obj is CharacterDataId other && Equals(other);
        public static Boolean operator ==(CharacterDataId left, CharacterDataId right) => left.Equals(right);
        public static Boolean operator !=(CharacterDataId left, CharacterDataId right) => !left.Equals(right);
        public override String ToString() => $"Character{Id:D3}";
        public override Int32 GetHashCode() => Id;
    }
}