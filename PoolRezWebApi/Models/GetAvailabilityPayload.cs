using PoolRezWebApi.Attributes;
using System.Text.Json.Serialization;

namespace PoolRezWebApi.Models
{
    public class GetAvailabilityPayload
    {
        public int ClubId = Constants.CLUB_ID;

        public int PrimaryCustomerId { get; set; }

        public int ItemId = Constants.BOOKABLE_ITEM_30_MIN_ID;
        
        public string? JsonSelectedBook = "null";

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndDate { get; set; }

    }
}
