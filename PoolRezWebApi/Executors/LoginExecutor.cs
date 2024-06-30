using Newtonsoft.Json;
using PoolRezWebApi.Helpers;
using PoolRezWebApi.Models;
using PoolRezWebApi.Services;

namespace PoolRezWebApi.Executors
{
    public class LoginExecutor : ILoginExecutor
    {
        private const string LOGIN_URI = "https://www.ourclublogin.com/api/CustomerAuth/CustomerLogin";

        private readonly HttpClient _client;
        private readonly IUserService _userService;

        public LoginExecutor(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient();
            _userService = userService;
        }

        public async Task<TokenData?> Login(LoginInformation loginInformation, CancellationToken cancellationToken)
        {
            if (loginInformation.Username == null || loginInformation.Password == null)
            {
                return null;
            }

            var requestContent = JsonContentCreator.Create(loginInformation);

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

            UserInfo userInfo = new UserInfo()
            {
                CustomerId = loginResponse.CustomerId,
                CustomerPermissions = loginResponse.CustomerPermissions,
                HomeClub = loginResponse.HomeClub,
                Token = loginResponse.data
            };

            _userService.SetUser(userInfo);
            //_userService.SetToken(loginResponse.data);

            return loginResponse.data;
        }
    }
}
