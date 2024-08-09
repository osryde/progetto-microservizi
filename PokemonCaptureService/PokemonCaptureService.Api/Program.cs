using PokemonCaptureService.Repository;
using Microsoft.EntityFrameworkCore;
using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Business;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Business.Kafka;
using PokemonCaptureService.Business.Profiles;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonCaptureServiceDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PokemonCaptureServiceDbContext", b => b.MigrationsAssembly("PokemonCaptureService.Repository")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddHttpClient<PokemonPopulateController>();


// Kafka Producer
builder.Services.AddKafkaProducerService<KafkaTopicsOutput, ProducerService>(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AssemblyMarker)); // Per l'auto risoluzione dei DTO

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PokemonCaptureServiceDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
