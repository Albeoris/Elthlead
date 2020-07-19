using System;
using System.IO;

namespace Elthlead.ResourceManager
{
    public struct AbsolutePath
    {
        public String Value { get; }

        private AbsolutePath(String absolutePath)
        {
            Value = absolutePath;
        }

        public override String ToString() => Value;
        public Boolean Equals(AbsolutePath other) => Value == other.Value;
        public override Boolean Equals(Object obj) => obj is AbsolutePath other && Equals(other);
        public override Int32 GetHashCode() => (Value != null ? Value.GetHashCode() : 0);
        public static Boolean operator ==(AbsolutePath left, AbsolutePath right) => left.Equals(right);
        public static Boolean operator !=(AbsolutePath left, AbsolutePath right) => !left.Equals(right);

        public static AbsolutePath Absolute(String absolutePath)
        {
            if (!Path.IsPathRooted(absolutePath))
                throw new NotSupportedException(absolutePath);

            return new AbsolutePath(absolutePath);
        }
    }
}