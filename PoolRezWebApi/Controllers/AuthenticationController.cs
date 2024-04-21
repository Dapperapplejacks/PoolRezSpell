using Microsoft.AspNetCore.Mvc;
using PoolRezWebApi.Models;

namespace PoolRezWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILoginExecutor _loginExecutor;

        public AuthenticationController(IHttpClientFactory clientFactory, ILoginExecutor loginExecutor)
        {
            _client = clientFactory.CreateClient();
            _loginExecutor = loginExecutor;
        }

        public HttpClient Client => _client;

        [HttpPost]
        public async Task<ActionResult<TokenData>> Login(LoginInformation loginInfo, CancellationToken cancellationToken)
        {
            if (loginInfo.Username == null || loginInfo.Password == null)
            {
                return new BadRequestResult();
            }

            TokenData? token = await _loginExecutor.Login(loginInfo, cancellationToken);

            if (token == null)
            {
                return new StatusCodeResult(500);
            }

            return new ActionResult<TokenData>(token);
        }
    }
}
