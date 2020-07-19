using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Elthlead.CSV
{
    internal sealed class CustomInt32Converter : Int32Converter
    {
        public static CustomInt32Converter Instance { get; } = new CustomInt32Converter();

        public override Object ConvertFromString(String text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrEmpty(text))
                return -1;

            if (text == "-" || text == "－" || text == "―" || text == "‐" || text == "ー" || text == " " || text == "\u3000")
                return -1;

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}