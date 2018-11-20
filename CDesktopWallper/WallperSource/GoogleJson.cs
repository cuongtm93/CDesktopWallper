namespace GoogleJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GoogleSearchResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }

        [JsonProperty("queries")]
        public Queries Queries { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("searchInformation")]
        public SearchInformation SearchInformation { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("kind")]
        public Kind Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("htmlTitle")]
        public string HtmlTitle { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("displayLink")]
        public string DisplayLink { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("htmlSnippet")]
        public string HtmlSnippet { get; set; }

        [JsonProperty("cacheId")]
        public string CacheId { get; set; }

        [JsonProperty("formattedUrl")]
        public string FormattedUrl { get; set; }

        [JsonProperty("htmlFormattedUrl")]
        public string HtmlFormattedUrl { get; set; }

        [JsonProperty("pagemap")]
        public Pagemap Pagemap { get; set; }
    }

    public partial class Pagemap
    {
        [JsonProperty("metatags")]
        public Dictionary<string, string>[] Metatags { get; set; }

        [JsonProperty("cse_thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public CseThumbnail[] CseThumbnail { get; set; }

        [JsonProperty("breadcrumb", NullValueHandling = NullValueHandling.Ignore)]
        public Breadcrumb[] Breadcrumb { get; set; }

        [JsonProperty("cse_image", NullValueHandling = NullValueHandling.Ignore)]
        public CseImage[] CseImage { get; set; }

        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>[] Document { get; set; }

        [JsonProperty("aggregaterating", NullValueHandling = NullValueHandling.Ignore)]
        public Aggregaterating[] Aggregaterating { get; set; }

        [JsonProperty("offer", NullValueHandling = NullValueHandling.Ignore)]
        public Offer[] Offer { get; set; }

        [JsonProperty("webapplication", NullValueHandling = NullValueHandling.Ignore)]
        public Webapplication[] Webapplication { get; set; }

        [JsonProperty("techarticle", NullValueHandling = NullValueHandling.Ignore)]
        public Techarticle[] Techarticle { get; set; }

        [JsonProperty("imageobject", NullValueHandling = NullValueHandling.Ignore)]
        public Imageobject[] Imageobject { get; set; }

        [JsonProperty("organization", NullValueHandling = NullValueHandling.Ignore)]
        public Organization[] Organization { get; set; }

        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public Brand[] Brand { get; set; }

        [JsonProperty("mobileapplication", NullValueHandling = NullValueHandling.Ignore)]
        public Mobileapplication[] Mobileapplication { get; set; }
    }

    public partial class Aggregaterating
    {
        [JsonProperty("ratingvalue")]
        public string Ratingvalue { get; set; }

        [JsonProperty("ratingcount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Ratingcount { get; set; }

        [JsonProperty("reviewcount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Reviewcount { get; set; }
    }

    public partial class Brand
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Breadcrumb
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class CseImage
    {
        [JsonProperty("src")]
        public string Src { get; set; }
    }

    public partial class CseThumbnail
    {
        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }

        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }

    public partial class Imageobject
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }

        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }
    }

    public partial class Mobileapplication
    {
        [JsonProperty("operatingsystem")]
        public string Operatingsystem { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("contentrating")]
        public string Contentrating { get; set; }

        [JsonProperty("applicationcategory")]
        public string Applicationcategory { get; set; }
    }

    public partial class Offer
    {
        [JsonProperty("price")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Price { get; set; }

        [JsonProperty("pricecurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string Pricecurrency { get; set; }

        [JsonProperty("availability", NullValueHandling = NullValueHandling.Ignore)]
        public string Availability { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public partial class Organization
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class Techarticle
    {
        [JsonProperty("datepublished")]
        public DateTimeOffset Datepublished { get; set; }

        [JsonProperty("datemodified")]
        public DateTimeOffset Datemodified { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("articlebody")]
        public string Articlebody { get; set; }
    }

    public partial class Webapplication
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("applicationcategory")]
        public string Applicationcategory { get; set; }

        [JsonProperty("interactioncount")]
        public string Interactioncount { get; set; }

        [JsonProperty("operatingsystem")]
        public string Operatingsystem { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class Queries
    {
        [JsonProperty("request")]
        public NextPage[] Request { get; set; }

        [JsonProperty("nextPage")]
        public NextPage[] NextPage { get; set; }
    }

    public partial class NextPage
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("totalResults")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalResults { get; set; }

        [JsonProperty("searchTerms")]
        public string SearchTerms { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("startIndex")]
        public long StartIndex { get; set; }

        [JsonProperty("inputEncoding")]
        public string InputEncoding { get; set; }

        [JsonProperty("outputEncoding")]
        public string OutputEncoding { get; set; }

        [JsonProperty("safe")]
        public string Safe { get; set; }

        [JsonProperty("cx")]
        public string Cx { get; set; }
    }

    public partial class SearchInformation
    {
        [JsonProperty("searchTime")]
        public double SearchTime { get; set; }

        [JsonProperty("formattedSearchTime")]
        public string FormattedSearchTime { get; set; }

        [JsonProperty("totalResults")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalResults { get; set; }

        [JsonProperty("formattedTotalResults")]
        public string FormattedTotalResults { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }
    }

    public enum Kind { CustomsearchResult };

    public partial class GoogleSearchResponse
    {
        public static GoogleSearchResponse FromJson(string json) => JsonConvert.DeserializeObject<GoogleSearchResponse>(json, GoogleJson.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GoogleSearchResponse self) => JsonConvert.SerializeObject(self, GoogleJson.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                KindConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class KindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Kind) || t == typeof(Kind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "customsearch#result")
            {
                return Kind.CustomsearchResult;
            }
            throw new Exception("Cannot unmarshal type Kind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Kind)untypedValue;
            if (value == Kind.CustomsearchResult)
            {
                serializer.Serialize(writer, "customsearch#result");
                return;
            }
            throw new Exception("Cannot marshal type Kind");
        }

        public static readonly KindConverter Singleton = new KindConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (Int64.TryParse(value, out long l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
