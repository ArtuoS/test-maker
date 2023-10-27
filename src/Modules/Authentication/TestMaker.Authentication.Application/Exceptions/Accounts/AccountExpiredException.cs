namespace TestMaker.Authentication.Application;

public class AccountExpiredException : Exception
{
    public AccountExpiredException(string message) : base(message)
    { }
}
