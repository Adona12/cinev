using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cinev
{



    public partial class Upcoming
    {
        [JsonProperty("results")]
        public List<Upcoming> Results { get; set; }




    }





    public partial class Upcoming
    {
        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get;  set; }

        public string FullPath { get { return "http://image.tmdb.org/t/p/w500" + PosterPath; }}
        public string FullBackPath { get { return "http://image.tmdb.org/t/p/w500" + BackdropPath; } }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("genre_ids")]
        public List<long> GenreIds { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        public string ReleaseDateString { get { return ((ReleaseDate.ToString()).Split(' '))[0]; } }
    }

    public partial class Upcoming
    {
        public static Upcoming FromJson(string json) => JsonConvert.DeserializeObject<Upcoming>(json, Cinev.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Upcoming self) => JsonConvert.SerializeObject(self, Cinev.Converter.Settings);
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
