using System;

namespace Elthlead.Injection
{
    public struct EndingDataId : IEquatable<EndingDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Id { get; }
        public Int32 Scene { get; }

        public EndingDataId(Int32 id, Int32 scene)
        {
            Id = id;
            Scene = scene;
        }

        public static Boolean TryParse(String key, out EndingDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length != 3)
            {
                value = default;
                return false;
            }

            if (array[0] != "Ending")
            {
                value = default;
                return false;
            }

            if (!Int32.TryParse(array[1], out var id))
            {
                value = default;
                return false;
            }

            if (!Int32.TryParse(array[2].Substring(1), out var scene))
            {
                value = default;
                return false;
            }

            value = new EndingDataId(id, scene);
            return true;
        }

        public static EndingDataId Parse(String key)
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

        public Boolean Equals(EndingDataId other) => Id == other.Id && Scene == other.Scene;
        public override Boolean Equals(Object obj) => obj is EndingDataId other && Equals(other);
        public static Boolean operator ==(EndingDataId left, EndingDataId right) => left.Equals(right);
        public static Boolean operator !=(EndingDataId left, EndingDataId right) => !left.Equals(right);
        public override String ToString() => $"Ending_{Id:D4}_S{Scene}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Scene;
                return hashCode;
            }
        }
    }
}