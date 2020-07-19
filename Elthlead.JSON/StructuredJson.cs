using System;
using System.IO;
using Elthlead.Framework;
using Newtonsoft.Json;

namespace Elthlead.JSON
{
    public static class StructuredJson
    {
        public static void Write(String outputPath, OrderedDictionary<String, TransifexEntry> map)
        {
            using (StreamWriter output = File.CreateText(outputPath))
            {
                JsonSerializer jsonWriter = new JsonSerializer {NullValueHandling = NullValueHandling.Ignore};
                jsonWriter.Serialize(output, map);
            }
        }

        public static OrderedDictionary<String, TransifexEntry> Read(String inputPath)
        {
            using (StreamReader input = File.OpenText(inputPath))
            {
                JsonSerializer jsonWriter = new JsonSerializer {NullValueHandling = NullValueHandling.Ignore};
                JsonTextReader reader = new JsonTextReader(input);
                return jsonWriter.Deserialize<OrderedDictionary<String, TransifexEntry>>(reader);
            }
        }
        
        public static OrderedDictionary<String, TransifexEntry> Read(Stream inputStream)
        {
            using (StreamReader input = new StreamReader(inputStream))
                return Read(input);
        }

        public static OrderedDictionary<String, TransifexEntry> Read(StreamReader input)
        {
            JsonSerializer jsonWriter = new JsonSerializer {NullValueHandling = NullValueHandling.Ignore};
            JsonTextReader reader = new JsonTextReader(input);
            return jsonWriter.Deserialize<OrderedDictionary<String, TransifexEntry>>(reader);
        }
    }
}