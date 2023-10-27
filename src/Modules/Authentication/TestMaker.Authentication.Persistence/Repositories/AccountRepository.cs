using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestMaker.Authentication.Domain;
using TestMaker.Authentication.Domain.Entities;
using TestMaker.Authentication.Persistence.Context;

namespace TestMaker.Authentication.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly AuthenticationDbContext context;

    public AccountRepository(AuthenticationDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> Create(Account account)
    {
        await context.Accounts.AddAsync(account);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Account>> Get()
    {
        return await context.Accounts.ToListAsync();
    }

    public async Task<Account> Get(Guid guid)
    {
        return await context.Accounts.FirstOrDefaultAsync(a => a.Guid == guid);
    }

    public async Task<Account> GetByExpression(Expression<Func<Account, bool>> expression)
    {
        return await context.Accounts.FirstOrDefaultAsync(expression);
    }

    public async Task<bool> Update(Account account)
    {
        context.Attach(account);
        return await context.SaveChangesAsync() > 0;
    }
}
