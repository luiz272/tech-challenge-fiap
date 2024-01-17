using Application.UseCases;
using Domain.Repositories;
using HealthChecks.UI.Client;
using Infra.Context;
using Infra.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

#region [Healthcheck]

builder.Services.AddHealthChecks()
    // .AddNpgSql(builder.Configuration.GetSection("DatabaseSettings:ConnectionString").Value, // Obs: tava dando erro
    //     name: "postgreSQL", tags: new string[] { "db", "data" })
    .AddRedis(builder.Configuration.GetSection("DatabaseSettings:ConnectionStringRedis").Value,
        name: "redis", tags: new string[] { "cache", "data" });

builder.Services.AddHealthChecksUI(opt =>
{
    opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
    opt.SetApiMaxActiveRequests(1); //api requests concurrency

    opt.AddHealthCheckEndpoint("default api", "/health"); //map health check api
}).AddInMemoryStorage();

#endregion

builder.Services.AddDbContext<TechContext>(options => options
        .UseNpgsql("User ID=postgres;Password=T3cHCh@113ng3;Host=localhost;Port=5432;Database=postgres;Pooling=true;")); // Mudar para ConnectionString do JSON // Obs: tava dando erro

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserUseCase, UserUseCase>();

builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IIngredientUseCase, IngredientUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseHttpsRedirection();

#region [Healthcheck]

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
}).UseHealthChecksUI(h => h.UIPath = "/health-ui");

#endregion

app.MapControllers();

app.Run();