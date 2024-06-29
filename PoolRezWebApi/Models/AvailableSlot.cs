namespace PoolRezWebApi.Models
{
    public class AvailableSlot
    {
        DateTime StartDateTime { get; set; }
        List<BookSelection> PossibleBookSelections = [];
    }
}
