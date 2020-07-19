using System;

namespace Elthlead.Injection
{
    public struct SystemDataId : IEquatable<SystemDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Message { get; }
        public Int32? Button { get; }

        public SystemDataId(Int32 message, Int32? button)
        {
            Message = message;
            Button = button;
        }

        public static Boolean TryParse(String key, out SystemDataId value)
        {
            String[] array = key.Split(__splitter);
            if (array.Length < 2)
            {
                value = default;
                return false;
            }

            if (array[0] != "System")
            {
                value = default;
                return false;
            }

            if (!Int32.TryParse(array[1], out var message))
            {
                value = default;
                return false;
            }

            Int32? button = null;

            if (array.Length > 2)
            {
                if (!Int32.TryParse(array[2].Substring(1), out var buttonIndex))
                {
                    value = default;
                    return false;
                }

                button = buttonIndex;
            }

            value = new SystemDataId(message, button);
            return true;
        }

        public static SystemDataId Parse(String key)
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

        public Boolean Equals(SystemDataId other) => Message == other.Message && Button == other.Button;
        public override Boolean Equals(Object obj) => obj is SystemDataId other && Equals(other);
        public static Boolean operator ==(SystemDataId left, SystemDataId right) => left.Equals(right);
        public static Boolean operator !=(SystemDataId left, SystemDataId right) => !left.Equals(right);
        public override String ToString() => $"System_{Message:D4}{(Button == null ? String.Empty : $"_B{Button.Value}")}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Message;
                if (Button != null)
                    hashCode = (hashCode * 397) ^ Button.Value;
                return hashCode;
            }
        }
    }
}