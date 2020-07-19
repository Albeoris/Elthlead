using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Elthlead.CSV
{
    public sealed class ItemData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String NameJapanese { get; set; }
        [Index(02)] public String ItemType { get; set; }
        [Index(03)] public String CanBeEquipped { get; set; }
        [Index(04)] public String ActivationCondition { get; set; }
        [Index(05)] public String CommandRange { get; set; }
        [Index(06)] public String CommandAT { get; set; }
        [Index(07)] public String ConductorDF { get; set; }
        [Index(08)] public String ConductorMAT { get; set; }
        [Index(09)] public String ConductorMDF { get; set; }
        [Index(10)] public String AT { get; set; }
        [Index(11)] public String DF { get; set; }
        [Index(12)] public String MAT { get; set; }
        [Index(13)] public String MDF { get; set; }
        [Index(14)] public String Mobility { get; set; }
        [Index(15)] public String MaximumHP { get; set; }
        [Index(16)] public String MaximumMP { get; set; }
        [Index(17)] public String hit { get; set; }
        [Index(18)] public String Avoidance { get; set; }
        [Index(19)] public String price { get; set; }
        [Index(20)] public String SpecialEffects { get; set; }
        [Index(21)] public String ChangeFlag { get; set; }
        [Index(22)] public String ChangeDestination { get; set; }
        [Index(23)] public String MagicName { get; set; }
        [Index(24)] public String SkillName { get; set; }
        [Index(25)] public String MercenaryName { get; set; }

        [Index(26)] public String DescriptionJapanese { get; set; }
        [Index(27)] public String ShortDescriptionJapanese { get; set; }

        [Index(28)] public String NameEnglish { get; set; }
        [Index(29)] public String DescriptionEnglish { get; set; }
        [Index(30)] public String ShortDescriptionEnglish { get; set; }

        [Index(31)] public String NameChinese { get; set; }
        [Index(32)] public String DescriptionChinese { get; set; }
        [Index(33)] public String ShortDescriptionChinese { get; set; }

        [Index(34)] public String NameKorean { get; set; }
        [Index(35)] public String DescriptionKorean { get; set; }
        [Index(36)] public String ShortDescriptionKorean { get; set; }

        public Localized Name => new Localized(NameJapanese, NameEnglish, NameChinese, NameKorean);
        public Localized Description => new Localized(DescriptionJapanese, DescriptionEnglish, DescriptionChinese, DescriptionKorean);
        public Localized ShortDescription => new Localized(ShortDescriptionJapanese, ShortDescriptionEnglish, ShortDescriptionChinese, ShortDescriptionKorean);
    }
}