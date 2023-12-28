using System.Text.Json.Serialization;

namespace PamiwShared.Models;

public class ServiceResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
