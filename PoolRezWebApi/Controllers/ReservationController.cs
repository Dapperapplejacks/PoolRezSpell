using Microsoft.AspNetCore.Mvc;
using PoolRezWebApi.Executors;

namespace PoolRezWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILoginExecutor _loginExecutor;

        public ReservationController(IHttpClientFactory clientFactory, ILoginExecutor loginExecutor)
        {
            _client = clientFactory.CreateClient();
            _loginExecutor = loginExecutor;
        }

        public HttpClient Client => _client;
    }
}
