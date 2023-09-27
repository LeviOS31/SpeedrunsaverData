using System.Text.Json.Serialization;

namespace Interfaces.RequestBody
{
    public struct UserBody
    {
        [JsonPropertyName("username")] public string Username { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("admin")] public bool Admin { get; set; }
    }
}
