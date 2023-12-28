using System.Text.Json.Serialization;

namespace PamiwShared.Models;

public class Publisher
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("books")]
    public ICollection<Book> Books { get; set; }
}
