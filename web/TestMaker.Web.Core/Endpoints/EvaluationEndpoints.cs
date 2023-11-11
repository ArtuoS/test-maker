namespace TestMaker.Web.Core.Endpoints
{
    public static class EvaluationEndpoints
    {
        public static string GetEvaluations => "https://localhost:7278/api/evaluations";
        public static string GetEvaluationByGuid => "https://localhost:7278/api/evaluations?guid={0}";
        public static string CreateOrUpdateEvaluation => "https://localhost:7278/api/evaluations";
    }
}
