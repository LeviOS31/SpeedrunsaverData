using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct SpeedrunBody
    {
        [JsonPropertyName("speedrunName")] public string SpeedrunName { get; set; }
        [JsonPropertyName("speedrunDescription")] public string SpeedrunDescription { get; set; }
        [JsonPropertyName("categoryId")] public int CategoryId { get; set; }
        [JsonPropertyName("platformId")] public int PlatformId { get; set; }
        [JsonPropertyName("userId")] public int UserId { get; set; }
        [JsonPropertyName("time")] public DateTime Time { get; set; }
        [JsonPropertyName("date")] public DateTime Date { get; set; }
        [JsonPropertyName("videoLink")] public string VideoLink { get; set; }
        [JsonPropertyName("status")] public int Status { get; set; }
    }
}
