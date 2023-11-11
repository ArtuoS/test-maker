namespace TestMaker.Authentication.Application.Exceptions.Accounts;

public class AccountExpiredException : Exception
{
    public AccountExpiredException(string message) : base(message)
    { }
}
