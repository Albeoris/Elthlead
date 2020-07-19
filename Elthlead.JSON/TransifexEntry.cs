using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Elthlead.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TransifexEntry
    {
        [JsonProperty("string")] public String Text { get; set; }
        [JsonProperty("context")] public String Context { get; set; }
        [JsonProperty("developer_comment")] public String Comment { get; set; }
        [JsonProperty("character_limit")] public Int32? CharacterLimit { get; set; }
    }
}