using AutoMapper;
using TestMaker.Evaluation.API.Profiles;
using TestMaker.Evaluation.Application.Interfaces;
using TestMaker.Evaluation.Application.Services;
using TestMaker.Evaluation.Domain.Interfaces;
using TestMaker.Evaluation.Persistence.Context;
using TestMaker.Evaluation.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(serviceProvider =>
{
    return new EvaluationDbContext("mongodb://localhost:27017", "test_maker");
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:49153";
    options.InstanceName = "evaluation_service";
});

builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers().AddNewtonsoftJson();
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
