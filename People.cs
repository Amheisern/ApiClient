using System;
using System.Text.Json.Serialization;

namespace GhibliStatus
{
    public class People
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("age")]
        public string Age { get; set; }
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }

        // public int id { get; set; }
        // public string text { get; set; }
        // public bool complete { get; set; }
        // public DateTime created_at { get; set; }
        // public DateTime updated_at { get; set; }

        // public string CompletedStatus
        // {
        //     get
        //     {
        //         return Complete ? "Completed" : "Not Complete";
        //         // if (complete)
        //         // {
        //         //     return "Complete";
        //         // }
        //         // else
        //         // {
        //         //     return "Not Complete";
        //         // }
        //     }
        // }
    }
}