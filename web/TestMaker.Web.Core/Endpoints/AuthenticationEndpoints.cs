namespace TestMaker.Web.Core.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static string Authenticate => $"{Environment.GetEnvironmentVariable("authentication_api_url")}/api/accounts/authenticate";
    }
}
