using System;

namespace Elthlead.Injection
{
    public struct ScenarioDataId : IEquatable<ScenarioDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Message { get; }
        public String Property { get; }

        public ScenarioDataId(Int32 message, String property)
        {
            Message = message;
            Property = property;
        }

        public static Boolean TryParse(String key, out ScenarioDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length < 3)
            {
                value = default;
                return false;
            }

            if (array[0] != "Scenario")
            {
                value = default;
                return false;
            }

            if (!Int32.TryParse(array[1], out var message))
            {
                value = default;
                return false;
            }

            String property = array[2];

            value = new ScenarioDataId(message, property);
            return true;
        }

        public static ScenarioDataId Parse(String key)
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

        public Boolean Equals(ScenarioDataId other) => Message == other.Message && Property == other.Property;
        public override Boolean Equals(Object obj) => obj is ScenarioDataId other && Equals(other);
        public static Boolean operator ==(ScenarioDataId left, ScenarioDataId right) => left.Equals(right);
        public static Boolean operator !=(ScenarioDataId left, ScenarioDataId right) => !left.Equals(right);
        public override String ToString() => $"Scenario_{Message:D4}_{Property}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Message;
                hashCode = (hashCode * 397) ^ Property.GetHashCode();
                return hashCode;
            }
        }
    }
}