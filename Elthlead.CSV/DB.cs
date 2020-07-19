using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Elthlead.CSV
{
    public static class DB
    {
        public static T[] ReadAll<T>(String filePath) where T : ICsvEntry
        {
            return EnumerateAll<T>(filePath).ToArray();
        }

        public static IEnumerable<T> EnumerateAll<T>(String filePath) where T : ICsvEntry
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.IgnoreQuotes = true;
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.TypeConverterCache.AddConverter<Int32>(CustomInt32Converter.Instance);

                Boolean started = false;
                while (csv.Read())
                {
                    if (!started)
                    {
                        if (csv.GetField(0) == "START")
                            started = true;
                        continue;
                    }

                    if (csv.GetField(0) == "END")
                        yield break;

                    yield return csv.GetRecord<T>();
                }
            }
        }
    }
}