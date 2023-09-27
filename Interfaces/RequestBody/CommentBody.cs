using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct CommentBody
    {
        [JsonPropertyName("commentText")] public string CommentText { get; set; }
        [JsonPropertyName("speedrunId")] public int SpeedrunId { get; set; }
        [JsonPropertyName("userId")] public int UserId { get; set; }
        [JsonPropertyName("date")] public DateTime Date { get; set; }
    }
}
