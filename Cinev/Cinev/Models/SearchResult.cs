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

        //public string ReleaseDateString { get { return ((ReleaseDate.ToString()).Split(' '))[0]; } }

        public string FullPath { get { return "http://image.tmdb.org/t/p/w500" + PosterPath; } }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public List<long> GenreIds { get; set; }


        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        //[JsonProperty("release_date")]
        //public DateTimeOffset ReleaseDate { get; set; }

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
