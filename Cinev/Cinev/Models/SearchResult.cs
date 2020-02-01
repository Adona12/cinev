using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cinev.Model
{

    public partial class SearchResult
    {
        [JsonProperty("results")]
        public List<SearchResult> Results { get; set; }




    }


    public partial class SearchResult
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        public static SearchResult FromJson(string json) => JsonConvert.DeserializeObject<SearchResult>(json, Cinev.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchResult self) => JsonConvert.SerializeObject(self, Cinev.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
