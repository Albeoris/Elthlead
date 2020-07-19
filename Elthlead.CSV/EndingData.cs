using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class EndingData : ICsvEntry
    {
        [Index(00)] public Int32 Id                     { get; set; }
        [Index(01)] public String EndingNumber          { get; set; }
        [Index(02)] public String Designation           { get; set; }
        [Index(03)] public String DisplayName           { get; set; }
        [Index(04)] public String CharacterName         { get; set; }
        [Index(05)] public String NameOfTheClass        { get; set; }
        [Index(06)] public String DistantView           { get; set; }
        [Index(07)] public String CloseView             { get; set; }
        [Index(08)] public String SystemVoiceChangeId   { get; set; }
        [Index(09)] public String Flag1                 { get; set; }
        [Index(10)] public String Flag2                 { get; set; }
        [Index(11)] public String NumberDestroyed       { get; set; }
        [Index(12)] public String NumberWithdrawals     { get; set; }
        [Index(13)] public String Scene1Japanese        { get; set; }
        [Index(14)] public String Scene2Japanese        { get; set; }
        [Index(15)] public String Scene3Japanese        { get; set; }
        [Index(16)] public String Scene4Japanese        { get; set; }
        [Index(17)] public String Scene5Japanese        { get; set; }
        [Index(18)] public String Scene6Japanese        { get; set; }
        [Index(19)] public String Scene7Japanese        { get; set; }
        [Index(20)] public String Scene8Japanese        { get; set; }
        [Index(21)] public String Scene1English         { get; set; }
        [Index(22)] public String Scene2English         { get; set; }
        [Index(23)] public String Scene3English         { get; set; }
        [Index(24)] public String Scene4English         { get; set; }
        [Index(25)] public String Scene5English         { get; set; }
        [Index(26)] public String Scene6English         { get; set; }
        [Index(27)] public String Scene7English         { get; set; }
        [Index(28)] public String Scene8English         { get; set; }
        [Index(29)] public String Unknown1              { get; set; }
        [Index(30)] public String Scene1Chinese         { get; set; }
        [Index(31)] public String Scene2Chinese         { get; set; }
        [Index(32)] public String Scene3Chinese         { get; set; }
        [Index(33)] public String Scene4Chinese         { get; set; }
        [Index(34)] public String Scene5Chinese         { get; set; }
        [Index(35)] public String Scene6Chinese         { get; set; }
        [Index(36)] public String Scene7Chinese         { get; set; }
        [Index(37)] public String Scene8Chinese         { get; set; }
        [Index(38)] public String Scene1Korean          { get; set; }
        [Index(39)] public String Scene2Korean          { get; set; }
        [Index(40)] public String Scene3Korean          { get; set; }
        [Index(41)] public String Scene4Korean          { get; set; }
        [Index(42)] public String Scene5Korean          { get; set; }
        [Index(43)] public String Scene6Korean          { get; set; }
        [Index(44)] public String Scene7Korean          { get; set; }
        [Index(45)] public String Scene8Korean          { get; set; }
        [Index(46)] public String Unknown2              { get; set; }

        public Localized Scene1 => new Localized(Scene1Japanese, Scene1English, Scene1Chinese, Scene1Korean);
        public Localized Scene2 => new Localized(Scene2Japanese, Scene2English, Scene2Chinese, Scene2Korean);
        public Localized Scene3 => new Localized(Scene3Japanese, Scene3English, Scene3Chinese, Scene3Korean);
        public Localized Scene4 => new Localized(Scene4Japanese, Scene4English, Scene4Chinese, Scene4Korean);
        public Localized Scene5 => new Localized(Scene5Japanese, Scene5English, Scene5Chinese, Scene5Korean);
        public Localized Scene6 => new Localized(Scene6Japanese, Scene6English, Scene6Chinese, Scene6Korean);
        public Localized Scene7 => new Localized(Scene7Japanese, Scene7English, Scene7Chinese, Scene7Korean);
        public Localized Scene8 => new Localized(Scene8Japanese, Scene8English, Scene8Chinese, Scene8Korean);
        
        public Localized this[Int32 sceneIndex]
        {
            get
            {
                switch (sceneIndex)
                {
                    case 0: return Scene1;
                    case 1: return Scene2;
                    case 2: return Scene3;
                    case 3: return Scene4;
                    case 4: return Scene5;
                    case 5: return Scene6;
                    case 6: return Scene7;
                    case 7: return Scene8;
                    default: throw new NotSupportedException(sceneIndex.ToString());
                }
            }
        }
    }
}