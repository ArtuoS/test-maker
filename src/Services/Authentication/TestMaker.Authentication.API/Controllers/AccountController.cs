using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TestMaker.Authentication.API.Models;
using TestMaker.Authentication.Domain.Entities;
using TestMaker.Authentication.Domain.Interfaces;

namespace TestMaker.Authentication.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository repository;

        public AccountController(IAccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid guid)
        {
            var account = await repository.Get(guid);
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Invalid account data.");
            }

            try
            {
                await repository.Create(account);
                return Created("api/accounts/" + account.Guid, account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AccountModel model)
        {
            try
            {
                var account = await repository.GetByExpression(Builders<Account>.Filter.And(
                    Builders<Account>.Filter.Eq(x => x.Login, model.Login),
                    Builders<Account>.Filter.Eq(x => x.Password, model.Password)
                ));

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
