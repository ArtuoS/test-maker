using Microsoft.Extensions.Options;
using TestMaker.Authentication.Application.UseCases.Accounts;
using TestMaker.Authentication.Domain.Interfaces;
using TestMaker.Authentication.Persistence.Context;
using TestMaker.Authentication.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Newtonsoft as default JSON Converter

builder.Services.AddSingleton<AuthenticationDbContext>(serviceProvider =>
{
    return new AuthenticationDbContext("mongodb://localhost:27017", "test_maker");
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateAccountUseCaseHandler).Assembly));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
