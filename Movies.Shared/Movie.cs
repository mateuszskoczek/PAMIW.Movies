using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Movies.Shared
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("director")]
        public string Director { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
