using Newtonsoft.Json;
using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public class LoginExecutor : ILoginExecutor
    {
        private const string LOGIN_URI = "https://www.ourclublogin.com/api/CustomerAuth/CustomerLogin";

        private readonly HttpClient _client;

        public LoginExecutor(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
        }

        public async Task<TokenData?> Login(LoginInformation loginInformation, CancellationToken cancellationToken)
        {
            if (loginInformation.Username == null || loginInformation.Password == null)
            {
                return null;
            }

            JsonContent requestContent = JsonContent.Create(loginInformation);
            requestContent.Headers.Add("x-companyid", "510670");
            requestContent.Headers.Add("x-customerid", "0");
            requestContent.Headers.Add("Origin", "https://www.ourclublogin.com");
            requestContent.Headers.Add("DNT", "1");
            requestContent.Headers.Add("Cookie", "coid=510670");

            var response = await _client.PostAsync(LOGIN_URI, requestContent, cancellationToken);
            if (response == null || !response.IsSuccessStatusCode)
            {
                return null;
            }

            var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);

            LoginResponse? loginResponse = JsonConvert.DeserializeObject<LoginResponse>(stringContent);

            if (loginResponse == null
                || loginResponse.LoginError != null
                || loginResponse.LoginResult != 1
                || loginResponse.data == null)
            {
                return null;
            }

            return loginResponse.data;
        }
    }
}
