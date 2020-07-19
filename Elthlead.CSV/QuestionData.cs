using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Elthlead.CSV
{
    public sealed class QuestionData : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String Type { get; set; } // 説明 (Explanation), ラング１説明 (Langrisser 1), ラング２説明 (Langrisser 2), 質問 (Question)

        [Index(02)] public String AnswerJapanese1 { get; set; }
        [Index(03)] public String AnswerJapanese2 { get; set; }
        [Index(04)] public String AnswerJapanese3 { get; set; }

        [Index(05)] public Int32 NextQuestion1 { get; set; }
        [Index(06)] public Int32 NextQuestion2 { get; set; }
        [Index(07)] public Int32 NextQuestion3 { get; set; }

        [Index(08)] public Int32 SkillA1 { get; set; }
        [Index(09)] public Int32 SkillB1 { get; set; }
        [Index(10)] public Int32 SkillC1 { get; set; }
        [Index(11)] public Int32 SkillD1 { get; set; }
        [Index(12)] public Int32 ItemA1 { get; set; }
        [Index(13)] public Int32 ItemB1 { get; set; }
        [Index(14)] public Int32 ItemC1 { get; set; }
        [Index(15)] public Int32 ItemD1 { get; set; }
        [Index(16)] public Int32 ItemE1 { get; set; }
        [Index(17)] public Int32 ItemF1 { get; set; }
        [Index(18)] public Int32 Magic1 { get; set; }
        [Index(19)] public Int32 Mercenary1 { get; set; }

        [Index(20)] public Int32 SkillA2 { get; set; }
        [Index(21)] public Int32 SkillB2 { get; set; }
        [Index(22)] public Int32 SkillC2 { get; set; }
        [Index(23)] public Int32 SkillD2 { get; set; }
        [Index(24)] public Int32 ItemA2 { get; set; }
        [Index(25)] public Int32 ItemB2 { get; set; }
        [Index(26)] public Int32 ItemC2 { get; set; }
        [Index(27)] public Int32 ItemD2 { get; set; }
        [Index(28)] public Int32 ItemE2 { get; set; }
        [Index(29)] public Int32 ItemF2 { get; set; }
        [Index(30)] public Int32 Magic2 { get; set; }
        [Index(31)] public Int32 Mercenary2 { get; set; }

        [Index(32)] public Int32 SkillA3 { get; set; }
        [Index(33)] public Int32 SkillB3 { get; set; }
        [Index(34)] public Int32 SkillC3 { get; set; }
        [Index(35)] public Int32 SkillD3 { get; set; }
        [Index(36)] public Int32 ItemA3 { get; set; }
        [Index(37)] public Int32 ItemB3 { get; set; }
        [Index(38)] public Int32 ItemC3 { get; set; }
        [Index(39)] public Int32 ItemD3 { get; set; }
        [Index(40)] public Int32 ItemE3 { get; set; }
        [Index(41)] public Int32 ItemF3 { get; set; }
        [Index(42)] public Int32 Magic3 { get; set; }
        [Index(43)] public Int32 Mercenary3 { get; set; }

        [Index(44)] public String VoiceFileName { get; set; }

        [Index(45)] public String QuestionJapanese { get; set; }
        [Index(46)] public String QuestionEnglish { get; set; }
        [Index(47)] public String QuestionChinese { get; set; }
        [Index(48)] public String QuestionKorean { get; set; }

        [Index(49)] public String AnswerEnglish1 { get; set; }
        [Index(50)] public String AnswerEnglish2 { get; set; }
        [Index(51)] public String AnswerEnglish3 { get; set; }

        [Index(52)] public String AnswerChinese1 { get; set; }
        [Index(53)] public String AnswerChinese2 { get; set; }
        [Index(54)] public String AnswerChinese3 { get; set; }

        [Index(55)] public String AnswerKorean1 { get; set; }
        [Index(56)] public String AnswerKorean2 { get; set; }
        [Index(57)] public String AnswerKorean3 { get; set; }

        public Localized Question => new Localized(QuestionJapanese, QuestionEnglish, QuestionChinese, QuestionKorean);

        public QuestionAnswer Answer1 => new QuestionAnswer(NextQuestion1,
            new Localized(AnswerJapanese1, AnswerEnglish1, AnswerChinese1, AnswerKorean1),
            SkillA1, SkillB1, SkillC1, SkillD1,
            ItemA1, ItemB1, ItemC1, ItemD1, ItemE1, ItemF1,
            Magic1, Mercenary1);

        public QuestionAnswer Answer2 => new QuestionAnswer(NextQuestion2,
            new Localized(AnswerJapanese2, AnswerEnglish2, AnswerChinese2, AnswerKorean2),
            SkillA2, SkillB2, SkillC2, SkillD2,
            ItemA2, ItemB2, ItemC2, ItemD2, ItemE2, ItemF2,
            Magic2, Mercenary2);

        public QuestionAnswer Answer3 => new QuestionAnswer(NextQuestion3,
            new Localized(AnswerJapanese3, AnswerEnglish3, AnswerChinese3, AnswerKorean3),
            SkillA3, SkillB3, SkillC3, SkillD3,
            ItemA3, ItemB3, ItemC3, ItemD3, ItemE3, ItemF3,
            Magic3, Mercenary3);

        public QuestionAnswer this[Int32 answerIndex]
        {
            get
            {
                switch (answerIndex)
                {
                    case 0: return Answer1;
                    case 1: return Answer2;
                    case 2: return Answer3;
                    default: throw new NotSupportedException(answerIndex.ToString());
                }
            }
        }

        public IEnumerable<QuestionAnswer> Answers
        {
            get
            {
                yield return Answer1;
                yield return Answer2;
                yield return Answer3;
            }
        }
    }
}