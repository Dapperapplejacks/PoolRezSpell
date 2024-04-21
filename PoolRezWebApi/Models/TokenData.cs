using System.Text.Json.Serialization;

namespace PoolRezWebApi.Models
{
    public class TokenData
    {
        public string? Token { get; set; }
        public string? TokenExpiration { get; set; }
    }
}
