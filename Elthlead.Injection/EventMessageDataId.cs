using System;

namespace Elthlead.Injection
{
    public struct EventMessageDataId : IEquatable<EventMessageDataId>
    {
        private static readonly Char[] __splitter = {'_'};

        public Int32 Game { get; }
        public Int32 Stage { get; }
        public Int32 Dialog { get; }
        public Int32 Index { get; }

        public EventMessageDataId(Int32 game, Int32 stage, Int32 dialog, Int32 index)
        {
            Game = game;
            Stage = stage;
            Dialog = dialog;
            Index = index;
        }

        public static EventMessageDataId Parse(String key)
        {
            try
            {
                String[] array = key.Split(__splitter);
                Int32 game = Int32.Parse(array[0].Substring(2));
                Int32 stage = Int32.Parse(array[1]);
                Int32 dialog = Int32.Parse(array[2]);
                Int32 index = Int32.Parse(array[3]);
                // Int32 id = Int32.Parse(array[4]);

                return new EventMessageDataId(game, stage, dialog, index);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(key, ex);
            }
        }

        public Boolean Equals(EventMessageDataId other) => Game == other.Game && Stage == other.Stage && Dialog == other.Dialog && Index == other.Index;
        public override Boolean Equals(Object obj) => obj is EventMessageDataId other && Equals(other);
        public static Boolean operator ==(EventMessageDataId left, EventMessageDataId right) => left.Equals(right);
        public static Boolean operator !=(EventMessageDataId left, EventMessageDataId right) => !left.Equals(right);
        public override String ToString() => $"EM{Game}_{Stage:D3}_{Dialog:D3}_{Index:D2}";

        public override Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = Game;
                hashCode = (hashCode * 397) ^ Stage;
                hashCode = (hashCode * 397) ^ Dialog;
                hashCode = (hashCode * 397) ^ Index;
                return hashCode;
            }
        }
    }
}