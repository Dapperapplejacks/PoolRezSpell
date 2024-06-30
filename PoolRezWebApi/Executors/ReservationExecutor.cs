using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoolRezWebApi.Attributes;
using PoolRezWebApi.Helpers;
using PoolRezWebApi.Models;
using PoolRezWebApi.Services;
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

        private UserInfo? _userInfo;

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

        public async Task<ActionResult<GetBookAvailabilityResponse>> GetAllReservations(CancellationToken cancellationToken)
        {
            _userInfo = _userService.GetUser();
            if (_userInfo is null)
            {
                return new UnauthorizedResult();
            }

            // GetAvailability, do from now till 2 weeks from now
            GetAvailabilityPayload payload = new GetAvailabilityPayload()
            {
                ClubId = Constants.CLUB_ID,
                PrimaryCustomerId = _userInfo.CustomerId,
                ItemId = Constants.BOOKABLE_ITEM_30_MIN_ID,
                JsonSelectedBook = "null",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(14),
                
            };

            var startDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            var endDate = DateTime.Now.AddDays(14).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            //var requestContent = JsonContentCreator.Create(payload);
            //var jsonSettings = new JsonSerializerSettings();
            //jsonSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
            //string jsonContent = JsonConvert.SerializeObject(payload, jsonSettings);
            //JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            //jsonOptions.Converters.Add(new CustomDateTimeConverter());
            //var requestContent = JsonContentCreator.Create(jsonContent, _userInfo);
            //HttpResponseMessage response = await _client.PostAsync(GET_BOOK_AVAILABILITY_URI, requestContent, cancellationToken);

            var request = new HttpRequestMessage(HttpMethod.Post, GET_BOOK_AVAILABILITY_URI);
            request.Headers.Add("DNT", "1");
            request.Headers.Add("Cookie", $"coid={Constants.COMPANY_ID}");
            request.Headers.Add("Origin", "https://www.ourclublogin.com");
            request.Headers.Add("x-companyid", Constants.COMPANY_ID.ToString());
            request.Headers.Add("x-customerid", _userInfo.CustomerId.ToString());
            var content = new StringContent($"{{\"ClubId\":{Constants.CLUB_ID},\"PrimaryCustomerId\":{_userInfo.CustomerId},\"ItemId\":{Constants.BOOKABLE_ITEM_30_MIN_ID},\"JsonSelectedBook\":\"null\",\"StartDate\":\"{startDate}\",\"EndDate\":\"{endDate}\"}}", null, "application/json");
            request.Content = content;
            var response = await _client.SendAsync(request, cancellationToken);

            
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

            return availabilityResponse;
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
