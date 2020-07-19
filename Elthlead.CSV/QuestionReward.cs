using System;
using CsvHelper.Configuration.Attributes;

namespace Elthlead.CSV
{
    public sealed class QuestionReward : ICsvEntry
    {
        [Index(00)] public Int32 Id { get; set; }
        [Index(01)] public String Type { get; set; } // Skill A, Skill C, Item A, Item C, Item E
        [Index(02)] public String Value1 { get; set; }
        [Index(03)] public String Value2 { get; set; }
        [Index(04)] public String Value3 { get; set; }
        [Index(05)] public String Value4 { get; set; }

        [Ignore]
        public String this[Int32 index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Value1;
                    case 1: return Value2;
                    case 2: return Value3;
                    case 3: return Value4;
                    default: throw new NotSupportedException(index.ToString());
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Value1 = value;
                        break;
                    case 1:
                        Value2 = value;
                        break;
                    case 2:
                        Value3 = value;
                        break;
                    case 3:
                        Value4 = value;
                        break;
                    default: throw new NotSupportedException(index.ToString());
                }
            }
        }
    }
}