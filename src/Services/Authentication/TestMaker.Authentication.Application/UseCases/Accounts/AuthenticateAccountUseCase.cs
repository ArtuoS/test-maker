using MediatR;
using MongoDB.Driver;
using System;
using System.Xml.Linq;
using TestMaker.Authentication.Application.Exceptions;
using TestMaker.Authentication.Application.Exceptions.Accounts;
using TestMaker.Authentication.Domain.Entities;
using TestMaker.Authentication.Domain.Interfaces;

namespace TestMaker.Authentication.Application.UseCases.Accounts;

public class AuthenticateAccountUseCase : IRequest<Account>
{
    public string RegisterUninter { get; set; }
    public string Password { get; set; }
}

public class AuthenticateAccountUseCaseHandler : IRequestHandler<AuthenticateAccountUseCase, Account>
{
    private readonly IAccountRepository repository;

    public AuthenticateAccountUseCaseHandler(IAccountRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Account> Handle(AuthenticateAccountUseCase request, CancellationToken cancellationToken)
    {
        ValidateRequest(request);
        var account = await repository.GetByExpression(Builders<Account>.Filter.And(
            Builders<Account>.Filter.Eq(x => x.Login, request.RegisterUninter),
            Builders<Account>.Filter.Eq(x => x.Password, request.Password)
        ));

        if (account is null)
            throw new NotFoundException("Conta não encontrada.");

        if (account.Expired)
            throw new AccountExpiredException(string.Format("Sua licença expirou em {0}", account.ExpirationDate));

        return account;
    }

    private void ValidateRequest(AuthenticateAccountUseCase request)
    {
        if (request.RegisterUninter is null)
            throw new ArgumentNullException(nameof(request.RegisterUninter));

        if (request.Password is null)
            throw new ArgumentNullException(nameof(request.Password));
    }
}
