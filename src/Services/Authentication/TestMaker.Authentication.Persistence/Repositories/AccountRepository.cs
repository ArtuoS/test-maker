using MongoDB.Driver;
using TestMaker.Authentication.Domain.Entities;
using TestMaker.Authentication.Domain.Interfaces;
using TestMaker.Authentication.Persistence.Context;

namespace TestMaker.Authentication.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AuthenticationDbContext context;

    public AccountRepository(AuthenticationDbContext context)
    {
        this.context = context;
    }

    public async Task Create(Account account)
    {
        await context.Accounts.InsertOneAsync(account);
    }

    public async Task<List<Account>> Get()
    {
        return await context.Accounts.Find(_ => true).ToListAsync();
    }

    public async Task<Account> Get(Guid guid)
    {
        var filter = Builders<Account>.Filter.Eq("Guid", guid);
        return await context.Accounts.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Account> GetByExpression(FilterDefinition<Account> filter)
    {
        return await context.Accounts.Find(filter).FirstOrDefaultAsync();
    }
}
