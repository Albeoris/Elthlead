using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Elthlead.CSV
{
    public sealed class GroundType : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String NameJapanese { get; set; }
        [Index(02)] public String IconNumber { get; set; }
        [Index(03)] public String MovementEffectDuringBattle { get; set; }
        [Index(04)] public String BattleBGCloseView { get; set; }
        [Index(05)] public String MovementType { get; set; }
        [Index(06)] public String LandMovementCost { get; set; }
        [Index(07)] public String MountedMovementCost { get; set; }
        [Index(08)] public String WaterTransferCost { get; set; }
        [Index(09)] public String FlightTravelCosts { get; set; }
        [Index(10)] public String DefenseCorrection { get; set; }
        [Index(11)] public String HitFix { get; set; }
        [Index(12)] public String HPRecoveryRate { get; set; }
        [Index(13)] public String MPRecoveryRate { get; set; }
        [Index(14)] public String NameEnglish { get; set; }
        [Index(15)] public String NameChinese { get; set; }
        [Index(16)] public String NameKorean { get; set; }

        public Localized Name => new Localized(NameJapanese, NameEnglish, NameChinese, NameKorean);
    }
}