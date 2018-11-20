// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var fbPostResultSuccess = FbPostResultSuccess.FromJson(jsonString);

namespace FacebookJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FbPostResultSuccess
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("post_supports_client_mutation_id")]
        public bool PostSupportsClientMutationId { get; set; }
    }

    public partial class FbPostResultSuccess
    {
        public static FbPostResultSuccess FromJson(string json) => JsonConvert.DeserializeObject<FbPostResultSuccess>(json, FacebookJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FbPostResultSuccess self) => JsonConvert.SerializeObject(self, FacebookJson.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public partial class FbPostResultError
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("error_subcode")]
        public long ErrorSubcode { get; set; }

        [JsonProperty("fbtrace_id")]
        public string FbtraceId { get; set; }
    }

    public partial class FbPostResultError
    {
        public static FbPostResultError FromJson(string json) => JsonConvert.DeserializeObject<FbPostResultError>(json, FacebookJson.Converter.Settings);
    }
}
