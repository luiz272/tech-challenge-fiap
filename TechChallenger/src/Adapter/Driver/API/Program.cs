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

builder.Services.AddDbContext<TechContext>(options => options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Mudar para ConnectionString do JSON // Obs: tava dando erro

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserUseCase, UserUseCase>();

builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IIngredientUseCase, IngredientUseCase>();

builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<ITagUseCase, TagUseCase>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderUseCase, OrderUseCase>();


builder.Services.AddTransient<IOrdersProductsRepository, OrdersProductsRepository>();

builder.Services.AddTransient<IOrdersIngredientsRepository, OrdersIngredientsRepository>();

builder.Services.AddTransient<IProductsIngredientsRepository, ProductsIngredientsRepository>();



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


app.MapControllers();

//using var scope = app.Services.CreateScope();

//var context = scope.ServiceProvider.GetRequiredService<TechContext>();
//await context.Database.MigrateAsync();

await app.RunAsync();
