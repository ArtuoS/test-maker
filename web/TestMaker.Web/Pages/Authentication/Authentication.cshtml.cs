using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestMaker.Web.Core;
using TestMaker.Web.Core.Endpoints;
using TestMaker.Web.Models;

namespace TestMaker.Web.Pages.Authentication
{
    public class AuthenticationModel : PageModel
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        private readonly ICaller _caller;

        public AuthenticationModel(ICaller caller)
        {
            _caller = caller;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string login, string password)
        {
            if (login is null || password is null)
            {
                return BadRequest("Preencha o login e a senha.");
            }

            var response = await _caller.PostAsync(AuthenticationEndpoints.Authenticate, new AccountModel { Login = login, Password = password });
            if (response is null)
            {
                return BadRequest("Usuário ou senha inválidos.");
            }

            return RedirectToPage("/evaluation/index");
        }
    }
}