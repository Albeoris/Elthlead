using System;
using System.Globalization;
using Elthlead.Framework;

namespace Elthlead.Injection
{
    public struct GoddessDialogDataId : IEquatable<GoddessDialogDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Question { get; }
        public Int32? Answer { get; }

        public GoddessDialogDataId(Int32 question, Int32? answer)
        {
            Question = question;
            Answer = answer;
        }

        public static GoddessDialogDataId Parse(String key)
        {
            try
            {
                String[] array = key.Split(__splitter);
                if (array.Length < 2)
                    throw new NotSupportedException("array.Length < 2");
                if (array[0] != "GoddessDialog")
                    throw new NotSupportedException("array[0] != \"GoddessDialog\"");

                Int32 question = Int32.Parse(array[1]);
                Int32? answer = null;

                if (array.Length > 2)
                    answer = Int32.Parse(array[2].Substring(1));

                return new GoddessDialogDataId(question, answer);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(key, ex);
            }
        }

        public Boolean Equals(GoddessDialogDataId other) => Question == other.Question && Answer == other.Answer;
        public override Boolean Equals(Object obj) => obj is GoddessDialogDataId other && Equals(other);
        public static Boolean operator ==(GoddessDialogDataId left, GoddessDialogDataId right) => left.Equals(right);
        public static Boolean operator !=(GoddessDialogDataId left, GoddessDialogDataId right) => !left.Equals(right);
        public override String ToString() => $"GoddessDialog_{Question:D2}{(Answer == null ? String.Empty : $"_A{Answer.Value}")}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Question;
                if (Answer != null)
                    hashCode = (hashCode * 397) ^ Answer.Value;
                return hashCode;
            }
        }
    }
}