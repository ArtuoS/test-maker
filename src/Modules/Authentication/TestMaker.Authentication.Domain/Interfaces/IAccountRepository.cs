using System.Linq.Expressions;
using TestMaker.Authentication.Domain.Entities;

namespace TestMaker.Authentication.Domain;

public interface IAccountRepository
{
    public Task<List<Account>> Get();
    public Task<Account> Get(Guid guid);
    public Task<bool> Create(Account account);
    public Task<bool> Update(Account account);
    public Task<Account> GetByExpression(Expression<Func<Account, bool>> expression);
}