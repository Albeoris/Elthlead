using System;

namespace Elthlead.Injection
{
    public struct GameWordId : IEquatable<GameWordId>
    {
        public Int32 Id { get; }

        public GameWordId(Int32 id)
        {
            Id = id;
        }

        public static Boolean TryParse(String key, out GameWordId value)
        {
            if (!key.StartsWith("GameWord"))
            {
                value = default;
                return false;
            }

            key = key.Substring("GameWord".Length);

            if (!Int32.TryParse(key, out var index))
            {
                value = default;
                return false;
            }

            value = new GameWordId(index);
            return true;
        }

        public static GameWordId Parse(String key)
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
        public Boolean Equals(GameWordId other) => Id == other.Id;
        public override Boolean Equals(Object obj) => obj is GameWordId other && Equals(other);
        public static Boolean operator ==(GameWordId left, GameWordId right) => left.Equals(right);
        public static Boolean operator !=(GameWordId left, GameWordId right) => !left.Equals(right);
        public override String ToString() => $"GameWord{Id:D3}";
    }
}