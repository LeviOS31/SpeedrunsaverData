using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct TokenBody
    {
        [JsonPropertyName("token")] public string Token { get; set; }
        [JsonPropertyName("accesforadmin")] public bool AccesForAdmin { get; set; }
        [JsonPropertyName("userid")] public int userID { get; set; }
    }
}
