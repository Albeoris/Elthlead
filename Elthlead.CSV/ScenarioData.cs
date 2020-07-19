using System;
using CsvHelper.Configuration.Attributes;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global

namespace Elthlead.CSV
{
    public sealed class ScenarioData : ICsvEntry
    {
        [Index(000)] public Int32 Id { get; set; }
        [Index(001)] public String TypeOfWork { get; set; }
        [Index(002)] public Int32 StageNumber { get; set; }
        [Index(003)] public Int32 ChapterNumber { get; set; }
        [Index(004)] public String FileName { get; set; }
        [Index(005)] public String AttributeNumber { get; set; }
        [Index(006)] public String StageTitleJapanese { get; set; }
        [Index(007)] public String Redin { get; set; }
        [Index(008)] public String Chris { get; set; }
        [Index(009)] public String Taylor { get; set; }
        [Index(010)] public String Nam { get; set; }
        [Index(011)] public String Jessica { get; set; }
        [Index(012)] public String Hawking { get; set; }
        [Index(013)] public String Thorn { get; set; }
        [Index(014)] public String Albert { get; set; }
        [Index(015)] public String Lance { get; set; }
        [Index(016)] public String Volkov { get; set; }
        [Index(017)] public String Lias { get; set; }
        [Index(018)] public String Leticia { get; set; }
        [Index(019)] public String Digos { get; set; }
        [Index(020)] public String Bezel { get; set; }
        [Index(021)] public String Naga { get; set; }
        [Index(022)] public String Nicolis { get; set; }
        [Index(023)] public String Betty { get; set; }
        [Index(024)] public String CharacterName1 { get; set; }
        [Index(025)] public String CharacterName2 { get; set; }
        [Index(026)] public String CharacterName3 { get; set; }
        [Index(027)] public String Elwin { get; set; }
        [Index(028)] public String Liana { get; set; }
        [Index(029)] public String Sherry { get; set; }
        [Index(030)] public String Keith { get; set; }
        [Index(031)] public String Scott { get; set; }
        [Index(032)] public String Lester { get; set; }
        [Index(033)] public String Aaron { get; set; }
        [Index(034)] public String Hane { get; set; }
        [Index(035)] public String Rouga { get; set; }
        [Index(036)] public String Leon { get; set; }
        [Index(037)] public String Imelda { get; set; }
        [Index(038)] public String Egbelt { get; set; }
        [Index(039)] public String Vargas { get; set; }
        [Index(040)] public String Sonia { get; set; }
        [Index(041)] public String DarkPrincess { get; set; }
        [Index(042)] public String Est { get; set; }
        [Index(043)] public String Ost { get; set; }
        [Index(044)] public String Lana { get; set; }
        [Index(045)] public String CharacterName4 { get; set; }
        [Index(046)] public String CharacterName5 { get; set; }
        [Index(047)] public String EnemyCommander1 { get; set; }
        [Index(048)] public String EnemyCommander2 { get; set; }
        [Index(049)] public String EnemyCommander3 { get; set; }
        [Index(050)] public String EnemyCommander4 { get; set; }
        [Index(051)] public String EnemyCommander5 { get; set; }
        [Index(052)] public String EnemyCommander6 { get; set; }
        [Index(053)] public String EnemyCommander7 { get; set; }
        [Index(054)] public String EnemyCommander8 { get; set; }
        [Index(055)] public String EnemyCommander9 { get; set; }
        [Index(056)] public String EnemyCommander10 { get; set; }
        [Index(057)] public String EnemyCommander11 { get; set; }
        [Index(058)] public String EnemyCommander12 { get; set; }
        [Index(059)] public String Positionchange { get; set; }
        [Index(060)] public String MVPreward { get; set; }
        [Index(061)] public String MVPrewarddata { get; set; }
        [Index(062)] public String Clearreward { get; set; }
        [Index(063)] public String AllyBGM { get; set; }
        [Index(064)] public String EnemyBGM { get; set; }
        [Index(065)] public String FlagNumberA { get; set; }
        [Index(066)] public String FlagName1Japanese { get; set; }
        [Index(067)] public String FlagNumberB { get; set; }
        [Index(068)] public String FlagName2Japanese { get; set; }
        [Index(069)] public String FlagNumberC { get; set; }
        [Index(070)] public String FlagName3Japanese { get; set; }
        [Index(071)] public String FlagNumberD { get; set; }
        [Index(072)] public String FlagName4Japanese { get; set; }
        [Index(073)] public String StagePrologJapanese { get; set; }
        [Index(074)] public String SimpleSynopsisJapanese { get; set; }
        [Index(075)] public String StageHintJapanese { get; set; }
        [Index(076)] public String MapNameJapanese { get; set; }
        [Index(077)] public String PlayerArmyNameJapanese { get; set; }
        [Index(078)] public String EnemyArmyNameJapanese { get; set; }
        [Index(079)] public String VictoryCondition1Japanese { get; set; }
        [Index(080)] public String DefeatCondition1Japanese { get; set; }
        [Index(081)] public String VictoryCondition2Japanese { get; set; }
        [Index(082)] public String DefeatCondition2Japanese { get; set; }
        [Index(083)] public String StageTitleEnglish { get; set; }
        [Index(084)] public String FlagName1English { get; set; }
        [Index(085)] public String FlagName2English { get; set; }
        [Index(086)] public String FlagName3English { get; set; }
        [Index(087)] public String FlagName4English { get; set; }
        [Index(088)] public String StagePrologEnglish { get; set; }
        [Index(089)] public String SimpleSynopsisEnglish { get; set; }
        [Index(090)] public String StageHintEnglish { get; set; }
        [Index(091)] public String MapNameEnglish { get; set; }
        [Index(092)] public String PlayerArmyNameEnglish { get; set; }
        [Index(093)] public String EnemyArmyNameEnglish { get; set; }
        [Index(094)] public String VictoryCondition1English { get; set; }
        [Index(095)] public String DefeatCondition1English { get; set; }
        [Index(096)] public String VictoryCondition2English { get; set; }
        [Index(097)] public String DefeatCondition2English { get; set; }
        [Index(098)] public String StageTitleChinese { get; set; }
        [Index(099)] public String FlagName1Chinese { get; set; }
        [Index(100)] public String FlagName2Chinese { get; set; }
        [Index(101)] public String FlagName3Chinese { get; set; }
        [Index(102)] public String FlagName4Chinese { get; set; }
        [Index(103)] public String StagePrologChinese { get; set; }
        [Index(104)] public String SimpleSynopsisChinese { get; set; }
        [Index(105)] public String StageHintChinese { get; set; }
        [Index(106)] public String MapNameChinese { get; set; }
        [Index(107)] public String PlayerArmyNameChinese { get; set; }
        [Index(108)] public String EnemyArmyNameChinese { get; set; }
        [Index(109)] public String VictoryCondition1Chinese { get; set; }
        [Index(110)] public String DefeatCondition1Chinese { get; set; }
        [Index(111)] public String VictoryCondition2Chinese { get; set; }
        [Index(112)] public String DefeatCondition2Chinese { get; set; }
        [Index(113)] public String StageTitleKorean { get; set; }
        [Index(114)] public String FlagName1Korean { get; set; }
        [Index(115)] public String FlagName2Korean { get; set; }
        [Index(116)] public String FlagName3Korean { get; set; }
        [Index(117)] public String FlagName4Korean { get; set; }
        [Index(118)] public String StagePrologKorean { get; set; }
        [Index(119)] public String SimpleSynopsisKorean { get; set; }
        [Index(120)] public String StageHintKorean { get; set; }
        [Index(121)] public String MapNameKorean { get; set; }
        [Index(122)] public String PlayerArmyNameKorean { get; set; }
        [Index(123)] public String EnemyArmyNameKorean { get; set; }
        [Index(124)] public String VictoryCondition1Korean { get; set; }
        [Index(125)] public String DefeatCondition1Korean { get; set; }
        [Index(126)] public String VictoryCondition2Korean { get; set; }
        [Index(127)] public String DefeatCondition2Korean { get; set; }

        public Localized StageTitle => new Localized(StageTitleJapanese, StageTitleEnglish, StageTitleChinese, StageTitleKorean);
        public Localized FlagName1 => new Localized(FlagName1Japanese, FlagName1English, FlagName1Chinese, FlagName1Korean);
        public Localized FlagName2 => new Localized(FlagName2Japanese, FlagName2English, FlagName2Chinese, FlagName2Korean);
        public Localized FlagName3 => new Localized(FlagName3Japanese, FlagName3English, FlagName3Chinese, FlagName3Korean);
        public Localized FlagName4 => new Localized(FlagName4Japanese, FlagName4English, FlagName4Chinese, FlagName4Korean);
        public Localized StageProlog => new Localized(StagePrologJapanese, StagePrologEnglish, StagePrologChinese, StagePrologKorean);
        public Localized SimpleSynopsis => new Localized(SimpleSynopsisJapanese, SimpleSynopsisEnglish, SimpleSynopsisChinese, SimpleSynopsisKorean);
        public Localized StageHint => new Localized(StageHintJapanese, StageHintEnglish, StageHintChinese, StageHintKorean);
        public Localized MapName => new Localized(MapNameJapanese, MapNameEnglish, MapNameChinese, MapNameKorean);
        public Localized PlayerArmyName => new Localized(PlayerArmyNameJapanese, PlayerArmyNameEnglish, PlayerArmyNameChinese, PlayerArmyNameKorean);
        public Localized EnemyArmyName => new Localized(EnemyArmyNameJapanese, EnemyArmyNameEnglish, EnemyArmyNameChinese, EnemyArmyNameKorean);

        public Localized VictoryCondition1 => new Localized(VictoryCondition1Japanese, VictoryCondition1English, VictoryCondition1Chinese, VictoryCondition1Korean);
        public Localized DefeatCondition1 => new Localized(DefeatCondition1Japanese, DefeatCondition1English, DefeatCondition1Chinese, DefeatCondition1Korean);

        public Localized VictoryCondition2 => new Localized(VictoryCondition2Japanese, VictoryCondition2English, VictoryCondition2Chinese, VictoryCondition2Korean);
        public Localized DefeatCondition2 => new Localized(DefeatCondition2Japanese, DefeatCondition2English, DefeatCondition2Chinese, DefeatCondition2Korean);
    }
}