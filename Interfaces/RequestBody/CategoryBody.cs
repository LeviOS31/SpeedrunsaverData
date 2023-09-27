using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct CategoryBody
    {
        [JsonPropertyName("categoryName")] public string CategoryName { get; set; }
        [JsonPropertyName("categoryDescription")] public string CategoryDescription { get; set; }
        [JsonPropertyName("gameId")] public int gameId { get; set; }
    }
}
