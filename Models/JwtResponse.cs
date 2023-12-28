using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PamiwShared.Models;

public class JwtResponse
{
    [JsonPropertyName("tokenType")]
    public string TokenType { get; set; }
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("issuedAt")]
    public DateTime IssuedAt { get; set; }
    [JsonPropertyName("expireAt")]
    public DateTime ExpireAt { get; set; }
}
