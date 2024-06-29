using Microsoft.AspNetCore.Mvc;
using PoolRezWebApi.Executors;
using PoolRezWebApi.Models;

namespace PoolRezWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IReservationExecutor _reservationExecutor;

        public ReservationController(IHttpClientFactory clientFactory, IReservationExecutor reservationExecutor)
        {
            _client = clientFactory.CreateClient();
            _reservationExecutor = reservationExecutor;
        }

        public HttpClient Client => _client;

        [HttpGet]
        [Route("GetAllAvailable")]
        public async Task<ActionResult<List<AvailableSlot>>> GetAllAvailableSlots(CancellationToken cancellationToken)
        {
            ActionResult<List<AvailableSlot>> slots = await _reservationExecutor.GetAllReservations(cancellationToken);

            return slots;
        }
    }
}
