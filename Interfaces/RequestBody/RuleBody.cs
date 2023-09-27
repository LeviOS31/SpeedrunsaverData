using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct RuleBody
    {
        [JsonPropertyName("ruleDescription")] public string RuleDescription { get; set; }
        [JsonPropertyName("categoryId")] public int CategoryId { get; set; }
    }
}
