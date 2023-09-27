using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct PlatformBody
    {
        [JsonPropertyName("platformName")] public string PlatformName { get; set; }
        [JsonPropertyName("releaseDate")] public DateTime ReleaseDate { get; set; }
        [JsonPropertyName("manufacturer")] public string Manufacturer { get; set; }
    }
}
