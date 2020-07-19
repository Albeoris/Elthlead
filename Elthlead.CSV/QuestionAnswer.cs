using System;

namespace Elthlead.CSV
{
    public sealed class QuestionAnswer
    {
        public QuestionAnswer(Int32 next, Localized answer, Int32 skillA, Int32 skillB, Int32 skillC, Int32 skillD, Int32 itemA, Int32 itemB, Int32 itemC, Int32 itemD, Int32 itemE, Int32 itemF, Int32 magic, Int32 mercenary)
        {
            Next = next;
            Answer = answer;
            SkillA = skillA;
            SkillB = skillB;
            SkillC = skillC;
            SkillD = skillD;
            ItemA = itemA;
            ItemB = itemB;
            ItemC = itemC;
            ItemD = itemD;
            ItemE = itemE;
            ItemF = itemF;
            Magic = magic;
            Mercenary = mercenary;
        }

        public Int32 Next { get; }
        public Localized Answer { get; }
        public Int32 SkillA { get; }
        public Int32 SkillB { get; }
        public Int32 SkillC { get; }
        public Int32 SkillD { get; }
        public Int32 ItemA { get; }
        public Int32 ItemB { get; }
        public Int32 ItemC { get; }
        public Int32 ItemD { get; }
        public Int32 ItemE { get; }
        public Int32 ItemF { get; }
        public Int32 Magic { get; }
        public Int32 Mercenary { get; }
    }
}