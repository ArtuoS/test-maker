using MongoDB.Driver;
using TestMaker.Evaluation.Domain.Interfaces;
using TestMaker.Evaluation.Persistence.Context;

namespace TestMaker.Evaluation.Persistence.Repositories;

public class EvaluationRepository : IEvaluationRepository
{
    private readonly EvaluationDbContext context;

    public EvaluationRepository(EvaluationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateOrUpdateAsync(Domain.Entities.Evaluation evaluation)
    {
        var filter = Builders<Domain.Entities.Evaluation>.Filter.Eq(w => w.Guid, evaluation.Guid);
        var options = new ReplaceOptions { IsUpsert = true };
        await context.Evaluations.ReplaceOneAsync(filter, evaluation, options);
    }

    public async Task<List<Domain.Entities.Evaluation>> Get()
    {
        return await context.Evaluations.Find(_ => true).ToListAsync();
    }

    public async Task<Domain.Entities.Evaluation> Get(string guid)
    {
        var filter = Builders<Domain.Entities.Evaluation>.Filter.Eq(w => w.Guid, guid);
        return await context.Evaluations.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Domain.Entities.Evaluation> GetByExpression(FilterDefinition<Domain.Entities.Evaluation> filter)
    {
        return await context.Evaluations.Find(filter).FirstOrDefaultAsync();
    }
}
