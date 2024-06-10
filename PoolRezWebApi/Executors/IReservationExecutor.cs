namespace PoolRezWebApi.Executors
{
    public interface IReservationExecutor
    {
        void GetAllReservations();

        void GetReservationInTimeFrame();

        void Reserve();
    }
}
