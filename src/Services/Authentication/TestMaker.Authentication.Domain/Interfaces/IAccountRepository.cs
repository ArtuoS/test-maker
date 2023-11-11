using MongoDB.Driver;
using System.Linq.Expressions;
using TestMaker.Authentication.Domain.Entities;

namespace TestMaker.Authentication.Domain.Interfaces;

public interface IAccountRepository
{
    public Task<List<Account>> Get();
    public Task<Account> Get(Guid guid);
    public Task Create(Account account);
    public Task<Account> GetByExpression(FilterDefinition<Account> filter);
}