namespace GoogleJson
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GoogleCustomSearchError
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public partial class Error
    {
        [JsonProperty("errors")]
        public ErrorElement[] Errors { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class ErrorElement
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extendedHelp")]
        public string ExtendedHelp { get; set; }
    }

    public partial class GoogleCustomSearchError
    {
        public static GoogleCustomSearchError FromJson(string json)
        {
            return JsonConvert.DeserializeObject<GoogleCustomSearchError>(json, GoogleJson.Converter.Settings);
        }
    }
       
   
}
