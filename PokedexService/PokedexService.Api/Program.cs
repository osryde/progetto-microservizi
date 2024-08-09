using PokedexService.Repository.Abstraction;
using PokedexService.Business.Abstraction;
using PokedexService.Repository;
using PokedexService.Business;
using Microsoft.EntityFrameworkCore;
using PokedexService.Business.Kafka;
using PokedexService.Business.Kafka.MessageHandlers;
using PokedexService.Business.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PokedexServiceDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PokedexServiceDbContext", b => b.MigrationsAssembly("PokedexService.Repository")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

builder.Services.AddAutoMapper(typeof(AssemblyMarker));
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PokedexServiceDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
