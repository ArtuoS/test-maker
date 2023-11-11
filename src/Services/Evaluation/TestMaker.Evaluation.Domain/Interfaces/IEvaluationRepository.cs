using MongoDB.Driver;

namespace TestMaker.Evaluation.Domain.Interfaces
{
    public interface IEvaluationRepository
    {
        Task CreateOrUpdateAsync(Domain.Entities.Evaluation evaluation);
        Task<List<Entities.Evaluation>> Get();
        Task<Entities.Evaluation> Get(string guid);
        Task<Entities.Evaluation> GetByExpression(FilterDefinition<Entities.Evaluation> filter);
    }
}
