using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PoolRezWebApi.Attributes;
using PoolRezWebApi.Helpers;
using PoolRezWebApi.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoolRezWebApi.Executors
{
    public class ReservationExecutor : IReservationExecutor
    {
        private const string GET_BOOK_AVAILABILITY_URI = "https://www.ourclublogin.com/api/Scheduling/GetBookAvailability";

        private readonly HttpClient _client;
        private readonly IUserService _userService;

        private readonly UserInfo? _userInfo;

        public ReservationExecutor(IHttpClientFactory clientFactory, IUserService userService)
        {
            _client = clientFactory.CreateClient();
            _userService = userService;
            _userInfo = _userService.GetUser();

            if (_userInfo is null || _userInfo.Token is null)
            {
                return;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userInfo.Token.Token);
        }

        public async Task<ActionResult<List<AvailableSlot>>> GetAllReservations(CancellationToken cancellationToken)
        {
            if (_userInfo is null)
            {
                return new UnauthorizedResult();
            }

            // GetAvailability, do from now till 2 weeks from now
            GetAvailabilityPayload payload = new GetAvailabilityPayload()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14),
                PrimaryCustomerId = _userInfo.CustomerId
            };

            var requestContent = JsonContentCreator.Create(payload);
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
            string jsonContent = JsonConvert.SerializeObject(payload, jsonSettings);
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.Converters.Add(new CustomDateTimeConverter());

            HttpResponseMessage response = await _client.PostAsJsonAsync(GET_BOOK_AVAILABILITY_URI, requestContent, options: jsonOptions, cancellationToken);
            if (response == null || !response.IsSuccessStatusCode)
            {
                return new StatusCodeResult(response is null ? 500 : (int)response.StatusCode);
            }

            var stringContent = await response.Content.ReadAsStringAsync(cancellationToken);

            GetBookAvailabilityResponse? availabilityResponse
                = JsonConvert.DeserializeObject<GetBookAvailabilityResponse>(stringContent);

            if (availabilityResponse == null
                || availabilityResponse.Availability == null)
            {
                return new StatusCodeResult(500);
            }

            return availabilityResponse.Availability;
        }

        public void GetReservationInTimeFrame()
        {
            throw new NotImplementedException();
        }

        public void Reserve()
        {
            throw new NotImplementedException();
        }
    }
}
