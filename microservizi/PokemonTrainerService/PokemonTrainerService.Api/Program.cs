using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Abstraction;
using PokemonTrainerService.Business;
using PokemonTrainerService.Business.Abstraction;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonTrainerServiceDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PokemonTrainerServiceDbContext", b => b.MigrationsAssembly("PokemonTrainerService.Repository")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();


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
