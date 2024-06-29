using Newtonsoft.Json;
using PoolRezWebApi.Attributes;
using PoolRezWebApi.Models;
using System.Text.Json;

namespace PoolRezWebApi.Helpers
{
    public static class JsonContentCreator
    {
        public static JsonContent Create(object payload)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.Converters.Add(new CustomDateTimeConverter());

            var json = JsonConvert.SerializeObject(payload, jsonSettings);

            JsonContent requestContent = JsonContent.Create(payload, options: jsonOptions);
            requestContent.Headers.Add("x-companyid", Constants.COMPANY_ID.ToString());
            requestContent.Headers.Add("x-customerid", "0");
            requestContent.Headers.Add("Origin", Constants.ORIGIN_URL);
            requestContent.Headers.Add("DNT", "1");
            requestContent.Headers.Add("Cookie", $"coid={Constants.COMPANY_ID}");

            return requestContent;
        }

        public static JsonContent Create(object payload, TokenData token)
        {
            JsonContent requestContent = Create(payload);
            requestContent.Headers.Add("Authorization", $"Bearer {token.Token}");

            return requestContent;
        }
    }
}
