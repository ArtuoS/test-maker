using Newtonsoft.Json;
using RestSharp;

namespace TestMaker.Web.Core
{
    public class Caller : ICaller
    {
        public async Task<RestResponse> PostAsync(string endpoint, object? parameters = null, string? accessToken = null)
        {
            using (var client = new RestClient(endpoint))
            {
                var request = new RestRequest(endpoint, Method.Post);
                if (parameters != null)
                {
                    request.AddBody(JsonConvert.SerializeObject(parameters));
                }

                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.AddHeader("Authorization", "Bearer " + accessToken);
                }

                return await client.ExecuteAsync(request);
            };
        }

        public async Task<RestResponse> GetAsync(string endpoint, object? parameters = null, string? accessToken = null)
        {
            using (var client = new RestClient(endpoint))
            {
                var request = new RestRequest(endpoint, Method.Get);
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.AddHeader("Authorization", "Bearer " + accessToken);
                }

                return await client.ExecuteAsync(request);
            };
        }
    }
}