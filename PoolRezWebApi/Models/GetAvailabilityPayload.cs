using Newtonsoft.Json;
using PoolRezWebApi.Attributes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoolRezWebApi.Models
{
    public class GetAvailabilityPayload
    {
        public int ClubId = Constants.CLUB_ID;

        public int PrimaryCustomerId { get; set; }

        public int ItemId = Constants.BOOKABLE_ITEM_30_MIN_ID;
        
        public string? JsonSelectedBook = "null";

        [System.Text.Json.Serialization.JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartDate { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
            return JsonConvert.SerializeObject(this, jsonSettings);
        }

    }
}
