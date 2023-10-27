using Microsoft.EntityFrameworkCore;
using TestMaker.Authentication.Application;
using TestMaker.Authentication.Domain;
using TestMaker.Authentication.Persistence;
using TestMaker.Authentication.Persistence.Context;
using TestMaker.Evaluation.Application.Interfaces;
using TestMaker.Evaluation.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddMemoryCache();
builder.Services.AddControllers();

builder.Services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlite("Data Source=Accounts.db"));

builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<IEvaluationService, EvaluationService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateAccountUseCaseHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();