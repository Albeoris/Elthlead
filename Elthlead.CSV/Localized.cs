using System;

namespace Elthlead.CSV
{
    public sealed class Localized
    {
        public Localized(String japanese, String english, String chinese, String korean)
        {
            Japanese = japanese;
            English = english;
            Chinese = chinese;
            Korean = korean;
        }

        public String Japanese { get; }
        public String English { get; }
        public String Chinese { get; }
        public String Korean { get; }

        public override String ToString() => English;
    }
}