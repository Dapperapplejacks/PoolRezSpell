
using Microsoft.AspNetCore.Mvc;
using PoolRezWebApi.Models;

namespace PoolRezWebApi.Executors
{
    public interface IReservationExecutor
    {
        Task<ActionResult<List<AvailableSlot>>> GetAllReservations(CancellationToken cancellationToken);

        void GetReservationInTimeFrame();

        void Reserve();
    }
}
