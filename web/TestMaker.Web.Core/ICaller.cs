using RestSharp;

namespace TestMaker.Web.Core
{
    public interface ICaller
    {
        Task<RestResponse> GetAsync(string endpoint, object? parameters = null, string? accessToken = null);
        Task<RestResponse> PostAsync(string endpoint, object? parameters = null, string? accessToken = null);
    }
}
