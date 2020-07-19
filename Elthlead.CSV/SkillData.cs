using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable ClassNeverInstantiated.Global

namespace Elthlead.CSV
{
    public sealed class SkillData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String NameJapanese { get; set; }
        [Index(02)] public String ClassName { get; set; }
        [Index(03)] public String SkillType { get; set; }
        [Index(04)] public String IconType { get; set; }
        [Index(05)] public String ActivationCondition { get; set; }
        [Index(06)] public String CommandRange { get; set; }
        [Index(07)] public String CommandAT { get; set; }
        [Index(08)] public String ConductorDF { get; set; }
        [Index(09)] public String ConductorMAT { get; set; }
        [Index(10)] public String ConductorMDF { get; set; }
        [Index(11)] public String AT { get; set; }
        [Index(12)] public String DF { get; set; }
        [Index(13)] public String MAT { get; set; }
        [Index(14)] public String MDF { get; set; }
        [Index(15)] public String Mobility { get; set; }
        [Index(16)] public String NumberOfMercenaries { get; set; }
        [Index(17)] public String MaximumHP { get; set; }
        [Index(18)] public String MaximumMP { get; set; }
        [Index(19)] public String Hit { get; set; }
        [Index(20)] public String Avoidance { get; set; }
        [Index(21)] public String SpecialAttackInfantry { get; set; }
        [Index(22)] public String SpecialAttackSpearman { get; set; }
        [Index(23)] public String SpecialAttackCavalry { get; set; }
        [Index(24)] public String SpecialAttackFlyingSoldier { get; set; }
        [Index(25)] public String SpecialAttackSailor { get; set; }
        [Index(26)] public String SpecialAttackWizard { get; set; }
        [Index(27)] public String SpecialAttackMonk { get; set; }
        [Index(28)] public String SpecialAttackBandit { get; set; }
        [Index(29)] public String SpecialAttackNobushi { get; set; }
        [Index(30)] public String SpecialAttackBow { get; set; }
        [Index(31)] public String SpecialAttackBarista { get; set; }
        [Index(32)] public String SpecialAttackDemons { get; set; }
        [Index(33)] public String SpecialAttackImmortality { get; set; }
        [Index(34)] public String SpecialAttackHighImmortality { get; set; }
        [Index(35)] public String SpecialAttackMonsterGel { get; set; }
        [Index(36)] public String SpecialAttackMonsterLand { get; set; }
        [Index(37)] public String SpecialAttackMonsterWater { get; set; }
        [Index(38)] public String SpecialAttackMonsterFly { get; set; }
        [Index(39)] public String SpecialAttackSpirit { get; set; }
        [Index(40)] public String SpecialAttackDragon { get; set; }
        [Index(41)] public String SpecialEffects { get; set; }

        [Index(42)] public String DescriptionJapanese { get; set; }
        [Index(43)] public String ShortDescriptionJapanese { get; set; }
        [Index(44)] public String NameEnglish { get; set; }
        [Index(45)] public String DescriptionEnglish { get; set; }
        [Index(46)] public String ShortDescriptionEnglish { get; set; }
        [Index(47)] public String NameChinese { get; set; }
        [Index(48)] public String DescriptionChinese { get; set; }
        [Index(49)] public String ShortDescriptionChinese { get; set; }
        [Index(50)] public String NameKorean { get; set; }
        [Index(51)] public String DescriptionKorean { get; set; }
        [Index(52)] public String ShortDescriptionKorean { get; set; }

        public Localized Name => new Localized(NameJapanese, NameEnglish, NameChinese, NameKorean);
        public Localized Description => new Localized(DescriptionJapanese, DescriptionEnglish, DescriptionChinese, DescriptionKorean);
        public Localized ShortDescription => new Localized(ShortDescriptionJapanese, ShortDescriptionEnglish, ShortDescriptionChinese, ShortDescriptionKorean);
    }
}