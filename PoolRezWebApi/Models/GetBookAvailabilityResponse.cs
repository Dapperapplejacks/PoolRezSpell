namespace PoolRezWebApi.Models
{
    public class GetBookAvailabilityResponse
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemBarcodeId { get; set; }
        public string Duration { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public double Price { get; set; }
        public int PriorityAssignedResourceTypeId { get; set; }
        public bool CustomerHasPunchesForItem { get; set; }
        public bool AllowOnlineMemberPurchase { get; set; }
        public bool DividePriceByMembers { get; set; }
        public List<Availability> Availability { get; set; }
        public int MaximumCustomersPerAppointment { get; set; }
    }

    public class Availability
    {
        public DateTime StartDay { get; set; }
        public List<AvailableTime> AvailableTimes { get; set; }
    }

    public class AvailableTime
    {
        public DateTime StartDateTime { get; set; }
        public List<List<BookSelection>> PossibleBookSelections { get; set; }
    }

    public class BookSelection
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ResourceTypeId { get; set; }
        public int AssignedResourceId { get; set; }
        public bool IsAssignedResourceSelectable { get; set; }
    }
}
