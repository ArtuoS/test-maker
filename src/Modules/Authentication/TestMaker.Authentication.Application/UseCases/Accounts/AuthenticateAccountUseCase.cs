using MediatR;
using TestMaker.Authentication.Domain;
using TestMaker.Authentication.Domain.Entities;

namespace TestMaker.Authentication.Application;

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

        var account = await repository.GetByExpression(w => w.RegisterUninter == request.RegisterUninter && w.Password == request.Password);
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
