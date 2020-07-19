using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class InfomationData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String Scene { get; set; }
        [Index(02)] public Int32 Unknown { get; set; }
        [Index(03)] public String MessageJapanese { get; set; }
        [Index(04)] public String ButtonDescription1Japanese { get; set; }
        [Index(05)] public String ButtonDescription2Japanese { get; set; }
        [Index(06)] public String ButtonDescription3Japanese { get; set; }
        [Index(07)] public String ButtonDescription4Japanese { get; set; }
        [Index(08)] public String MessageEnglish { get; set; }
        [Index(09)] public String ButtonDescription1English { get; set; }
        [Index(10)] public String ButtonDescription2English { get; set; }
        [Index(11)] public String ButtonDescription3English { get; set; }
        [Index(12)] public String ButtonDescription4English { get; set; }
        [Index(13)] public String PlaceToDisplay { get; set; }
        [Index(14)] public String MessageChinese { get; set; }
        [Index(15)] public String ButtonDescription1Chinese { get; set; }
        [Index(16)] public String ButtonDescription2Chinese { get; set; }
        [Index(17)] public String ButtonDescription3Chinese { get; set; }
        [Index(18)] public String ButtonDescription4Chinese { get; set; }
        [Index(19)] public String MessageKorean { get; set; }
        [Index(20)] public String ButtonDescription1Korean { get; set; }
        [Index(21)] public String ButtonDescription2Korean { get; set; }
        [Index(22)] public String ButtonDescription3Korean { get; set; }
        [Index(23)] public String ButtonDescription4Korean { get; set; }

        public Localized Message => new Localized(MessageJapanese, MessageEnglish, MessageChinese, MessageKorean);
        public Localized ButtonDescription1 => new Localized(ButtonDescription1Japanese, ButtonDescription1English, ButtonDescription1Chinese, ButtonDescription1Korean);
        public Localized ButtonDescription2 => new Localized(ButtonDescription2Japanese, ButtonDescription2English, ButtonDescription2Chinese, ButtonDescription2Korean);
        public Localized ButtonDescription3 => new Localized(ButtonDescription3Japanese, ButtonDescription3English, ButtonDescription3Chinese, ButtonDescription3Korean);
        public Localized ButtonDescription4 => new Localized(ButtonDescription4Japanese, ButtonDescription4English, ButtonDescription4Chinese, ButtonDescription4Korean);

        public Localized this[Int32 buttonIndex]
        {
            get
            {
                switch (buttonIndex)
                {
                    case 0: return ButtonDescription1;
                    case 1: return ButtonDescription2;
                    case 2: return ButtonDescription3;
                    case 3: return ButtonDescription4;
                    default: throw new NotSupportedException(buttonIndex.ToString());
                }
            }
        }
    }
}