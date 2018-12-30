using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlaylistMaker.Core.Models
{
    public class ExternalUrls
    {

        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }

    public class Followers
    {

        [JsonProperty("href")]
        public object Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Image
    {

        [JsonProperty("height")]
        public object Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public object Width { get; set; }
    }

    public class User
    {

        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public IList<Image> Images { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }


}
