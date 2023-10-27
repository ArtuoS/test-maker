using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestMaker.Authentication.Application;
using TestMaker.Evaluation.Application.Interfaces;

namespace TestMaker.Web.Pages.Authentication
{
    public class AuthenticationModel : PageModel
    {
        public string? RegistrationNumber { get; set; }
        public string? Password { get; set; }

        private readonly IMediator mediator;

        public AuthenticationModel(IMediator mediator, ICacheService cacheService)
        {
            this.mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string registrationNumber, string password)
        {
            try
            {
                var account = await mediator.Send(new AuthenticateAccountUseCase
                {
                    RegisterUninter = registrationNumber,
                    Password = password
                });

                return new OkObjectResult(account);
            }
            catch (AccountExpiredException)
            {
                return new UnauthorizedResult();
            }
            catch (NotFoundException)
            {
                return new NotFoundResult();
            }
        }
    }
}