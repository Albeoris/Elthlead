using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class EventMessage : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String GameType { get; set; }
        [Index(02)] public Int32 ScenarioNumber { get; set; }
        [Index(03)] public Int32 ConversationNumber { get; set; }
        [Index(04)] public Int32 SentenceNumber { get; set; }
        [Index(05)] public String CharacterName { get; set; }
        [Index(06)] public String CharacterForCoordinate { get; set; }
        [Index(07)] public String CoordinateX { get; set; }
        [Index(08)] public String CoordinateY { get; set; }
        [Index(09)] public String Window { get; set; }
        [Index(10)] public String Background { get; set; }
        [Index(11)] public String Facial { get; set; }
        [Index(12)] public String DisplayPosition { get; set; }
        [Index(13)] public String VoiceFile { get; set; }
        [Index(14)] public String MessageJp { get; set; }
        [Index(15)] public String MessageEn { get; set; }
        [Index(16)] public String MessageCh { get; set; }
        [Index(17)] public String MessageKr { get; set; }

        public String GetKey()
        {
            String gameType = GameType == "ラング１" ? "EM1" : throw new NotSupportedException(GameType);
            return $"{gameType}_{ScenarioNumber:D3}_{ConversationNumber:D3}_{SentenceNumber:D2}_{Id:D5}";
        }
    }
}