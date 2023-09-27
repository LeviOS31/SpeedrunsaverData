using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct GameBody
    {
        [JsonPropertyName("gameName")] public string GameName { get; set; }
        [JsonPropertyName("gameDescription")] public string GameDescription { get; set; }
        [JsonPropertyName("developer")] public string Developer { get; set; }
        [JsonPropertyName("publisher")] public string Publisher { get; set; }
        [JsonPropertyName("releaseDate")] public DateTime ReleaseDate { get; set; }
    }
}
