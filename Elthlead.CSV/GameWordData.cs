using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class GameWordData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String Use { get; set; }
        [Index(02)] public String DesignatedNumber { get; set; }
        [Index(03)] public String MessageJapanese { get; set; }
        [Index(04)] public String MessageEnglish { get; set; }
        [Index(05)] public String PlaceToDisplay { get; set; }
        [Index(06)] public String MessageChinese { get; set; }
        [Index(07)] public String MessageKorean { get; set; }

        public Localized Text => new Localized(MessageJapanese, MessageEnglish, MessageChinese, MessageKorean);
    }
}