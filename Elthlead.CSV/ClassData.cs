using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace Elthlead.CSV
{
    public sealed class ClassData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String ClassName { get; set; }
        [Index(02)] public String DisplayNameJapanese { get; set; }
        [Index(03)] public String DisplayNameEnglish { get; set; }
        [Index(04)] public String AnimationFileName { get; set; }
        [Index(05)] public String CharacterSize { get; set; }
        [Index(06)] public String CommanderMercenary { get; set; }
        [Index(07)] public String SoldierType { get; set; }
        [Index(08)] public String Mobility { get; set; }
        [Index(09)] public String CommandRange { get; set; }
        [Index(10)] public String CommandAT { get; set; }
        [Index(11)] public String ConductorDF { get; set; }
        [Index(12)] public String ConductorMAT { get; set; }
        [Index(13)] public String ConductorMDF { get; set; }
        [Index(14)] public String MovementType { get; set; }
        [Index(15)] public String MaximumEnhancementLevel { get; set; }
        [Index(16)] public String NumberOfMercenaries { get; set; }
        [Index(17)] public String AttackMovementSpeed { get; set; }
        [Index(18)] public String EscortCharacter { get; set; }
        [Index(19)] public String WeaponType { get; set; }
        [Index(20)] public String EarnedExperienceValue { get; set; }
        [Index(21)] public String FundsEarned { get; set; }
        [Index(22)] public String EmploymentWage { get; set; }
        [Index(23)] public String MaximumHP { get; set; }
        [Index(24)] public String MaximumMP { get; set; }
        [Index(25)] public String PhysicalAttackPower { get; set; }
        [Index(26)] public String PhysicalDefense { get; set; }
        [Index(27)] public String MagicAttackPower { get; set; }
        [Index(28)] public String MagicDefense { get; set; }
        [Index(29)] public String LandTerrainAdaptation { get; set; }
        [Index(30)] public String WaterTerrainAdaptation { get; set; }
        [Index(31)] public String AerialTerrainAdaptation { get; set; }
        [Index(32)] public String IndoorTerrainAdaptation { get; set; }
        [Index(33)] public String MagicForEnemyCommander1 { get; set; }
        [Index(34)] public String MagicForEnemyCommander2 { get; set; }
        [Index(35)] public String SkillForEnemyCommander1 { get; set; }
        [Index(36)] public String SkillForEnemyCommander2 { get; set; }
        [Index(37)] public String DescriptionJapanese { get; set; }
        [Index(38)] public String DescriptionEnglish { get; set; }
        [Index(39)] public String DescriptionChinese { get; set; }
        [Index(40)] public String DescriptionKorean { get; set; }
        [Index(41)] public String DisplayNameChinese { get; set; }
        [Index(42)] public String DisplayNameKorean { get; set; }

        public Localized Description => new Localized(DescriptionJapanese, DescriptionEnglish, DescriptionChinese, DescriptionKorean);
        public Localized DisplayName => new Localized(DisplayNameJapanese, DisplayNameEnglish, DisplayNameChinese, DisplayNameKorean);
    }
}