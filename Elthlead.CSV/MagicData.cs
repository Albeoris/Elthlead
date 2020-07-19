using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global

namespace Elthlead.CSV
{
    public sealed class MagicData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String NameJapanese { get; set; }
        [Index(02)] public String DesignatedName { get; set; }
        [Index(03)] public String OpenLv { get; set; }
        [Index(04)] public String MPConsumption { get; set; }
        [Index(05)] public String RequiredEquipment { get; set; }
        [Index(06)] public String Type { get; set; }
        [Index(07)] public String Target { get; set; }
        [Index(08)] public String infantry { get; set; }
        [Index(09)] public String SpearSoldier { get; set; }
        [Index(10)] public String cavalry { get; set; }
        [Index(11)] public String FlyingSoldiers { get; set; }
        [Index(12)] public String Sailor { get; set; }
        [Index(13)] public String Wizard { get; set; }
        [Index(14)] public String Monk { get; set; }
        [Index(15)] public String Bandit { get; set; }
        [Index(16)] public String Ambush { get; set; }
        [Index(17)] public String bow { get; set; }
        [Index(18)] public String Barista { get; set; }
        [Index(19)] public String Demon { get; set; }
        [Index(20)] public String Immortality { get; set; }
        [Index(21)] public String HighImmortality { get; set; }
        [Index(22)] public String MonsterGel { get; set; }
        [Index(23)] public String MonsterLand { get; set; }
        [Index(24)] public String MonsterWater { get; set; }
        [Index(25)] public String MonsterFlying { get; set; }
        [Index(26)] public String Spirit { get; set; }
        [Index(27)] public String dragon { get; set; }
        [Index(28)] public String RangeSpecification { get; set; }
        [Index(29)] public String MaximumRange { get; set; }
        [Index(30)] public String RangeOfEffect { get; set; }
        [Index(31)] public String SpecialEffects { get; set; }
        [Index(32)] public String EffectTime { get; set; }
        [Index(33)] public String HitRate { get; set; }
        [Index(34)] public String OffensivePower { get; set; }
        [Index(35)] public String AttackCorrection { get; set; }
        [Index(36)] public String DefenseCorrection { get; set; }
        [Index(37)] public String MagicCorrection { get; set; }
        [Index(38)] public String ResistanceCorrection { get; set; }
        [Index(39)] public String HitCorrection { get; set; }
        [Index(40)] public String AvoidanceCorrection { get; set; }
        [Index(41)] public String MovementCorrection { get; set; }
        [Index(42)] public String GeneralPurpose { get; set; }
        [Index(43)] public String DescriptionJapanese { get; set; }
        [Index(44)] public String NameEnglish { get; set; }
        [Index(45)] public String DescriptionEnglish { get; set; }
        [Index(46)] public String AppearToTheSurgeon { get; set; }
        [Index(47)] public String ImpactPoint { get; set; }
        [Index(48)] public String Target2 { get; set; }
        [Index(49)] public String Other { get; set; }
        [Index(50)] public String VoiceFileNameForuniqueCharacter { get; set; }
        [Index(51)] public String VoiceFileNameForGeneralPurposeCharacters { get; set; }
        [Index(52)] public String WhenCastingSE { get; set; }
        [Index(53)] public String InvokingSE { get; set; }
        [Index(54)] public String SuccessSE { get; set; }
        [Index(55)] public String FailureSE { get; set; }
        [Index(56)] public String NameChinese { get; set; }
        [Index(57)] public String DescriptionChinese { get; set; }
        [Index(58)] public String NameKorean { get; set; }
        [Index(59)] public String DescriptionKorean { get; set; }

        public Localized Name => new Localized(NameJapanese, NameEnglish, NameChinese, NameKorean);
        public Localized Description => new Localized(DescriptionJapanese, DescriptionEnglish, DescriptionChinese, DescriptionKorean);
    }
}