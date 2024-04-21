using System.Text.Json.Serialization;

namespace PoolRezWebApi.Models
{
    public class LoginResponse
    {
        public int LoginResult { get; set; }
        public string? LoginError { get; set; }
        public int CustomerId { get; set; }
        public object? CustomerName { get; set; }
        public string? BarcodeId { get; set; }
        public int FamilyMemberCount { get; set; }
        public int HomeClub { get; set; }
        public string? LastSuccessfulLogin { get; set; }
        public int CustomerPermissions { get; set; }
        //[JsonPropertyName("data")]
        //public Token? Token { get; set; }
        public TokenData? data { get; set; }
        public object? Branding { get; set; }
        public string? CaptchaPublicKey { get; set; }
        public string? CustomerNeedsDob { get; set; }
        public string? UserName { get; set; }
    }
}
