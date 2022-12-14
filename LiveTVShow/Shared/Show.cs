using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LiveTVAdmin.Shared
{
    public class Show
    {
        [Required]
        [JsonProperty("id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("url")]
        public string Url { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}
