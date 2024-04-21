using System.Text.Json.Serialization;

namespace PoolRezWebApi.Models
{
    public class LoginInformation
    {
        public LoginInformation(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [JsonPropertyName("UserLogin")]
        public string Username { get; set; }

        [JsonPropertyName("Pswd")]
        public string Password { get; set; }
    }
}
