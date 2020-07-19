using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class CharacterData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String Name { get; set; }
        [Index(02)] public String DisplayNameJapanese { get; set; }
        [Index(03)] public String FileName { get; set; }
        [Index(04)] public String RegisteredMembers { get; set; }
        [Index(05)] public String CommanderMercenary { get; set; }
        [Index(06)] public String GrowthType { get; set; }
        [Index(07)] public String MaximumHP { get; set; }
        [Index(08)] public String MaximumMP { get; set; }
        [Index(09)] public String PhysicalAttackPower { get; set; }
        [Index(10)] public String PhysicalDefense { get; set; }
        [Index(11)] public String MagicAttackPower { get; set; }
        [Index(12)] public String MagicDefense { get; set; }
        [Index(13)] public String Dexterity { get; set; }
        [Index(14)] public String Agility { get; set; }
        [Index(15)] public String Luck { get; set; }
        [Index(16)] public String StatusErrorInvalid { get; set; }
        [Index(17)] public String Partner1 { get; set; }
        [Index(18)] public String Partner2 { get; set; }
        [Index(19)] public String Partner3 { get; set; }
        [Index(20)] public String Partner4 { get; set; }
        [Index(21)] public String MagicForEnemyCommander1 { get; set; }
        [Index(22)] public String MagicForEnemyCommanders2 { get; set; }
        [Index(23)] public String SkillForEnemyCommander1 { get; set; }
        [Index(24)] public String EnemyCommanderSkill2 { get; set; }
        [Index(25)] public String DisplayNameEnglish { get; set; }
        [Index(26)] public String DisplayNameChinese { get; set; }
        [Index(27)] public String DisplayNameKorean { get; set; }

        public Localized DisplayName => new Localized(DisplayNameJapanese, DisplayNameEnglish, DisplayNameChinese, DisplayNameKorean);
    }
}