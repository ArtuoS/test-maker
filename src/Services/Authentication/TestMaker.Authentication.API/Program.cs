using Microsoft.Extensions.Options;
using TestMaker.Authentication.Application.UseCases.Accounts;
using TestMaker.Authentication.Domain.Interfaces;
using TestMaker.Authentication.Persistence.Context;
using TestMaker.Authentication.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Newtonsoft as default JSON Converter

builder.Services.AddSingleton(serviceProvider =>
{
    return new AuthenticationDbContext(Environment.GetEnvironmentVariable("mongo_db_connection_string"), Environment.GetEnvironmentVariable("mongo_db_database_name"));
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
