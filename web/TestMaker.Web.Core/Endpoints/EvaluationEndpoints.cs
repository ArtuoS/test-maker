namespace TestMaker.Web.Core.Endpoints
{
    public static class EvaluationEndpoints
    {
        public static string GetEvaluations => $"{Environment.GetEnvironmentVariable("evaluation_api_url")}/api/evaluations";
        public static string GetEvaluationByGuid => $"{Environment.GetEnvironmentVariable("evaluation_api_url")}/api/evaluations?guid={0}";
        public static string CreateOrUpdateEvaluation => $"{Environment.GetEnvironmentVariable("evaluation_api_url")}/api/evaluations";
    }
}
