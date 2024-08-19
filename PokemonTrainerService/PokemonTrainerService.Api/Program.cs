using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Abstraction;
using PokemonTrainerService.Business;
using PokemonTrainerService.Business.Abstraction;
using PokemonTrainerService.ClientHttp;
using PokemonTrainerService.ClientHttp.Abstraction;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerService.Business.Kafka;
using PokemonTrainerService.Business.Profiles;
using PokemonTrainerService.Business.Kafka.MessageHandlers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonTrainerServiceDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PokemonTrainerServiceDbContext", b => b.MigrationsAssembly("PokemonTrainerService.Repository")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IClientHttp, ClientHttp>();

// ClientHttp da contattare ( PokedexService )
builder.Services.AddHttpClient<PokedexService.ClientHttp.Abstraction.IClientHttp, PokedexService.ClientHttp.ClientHttp>("PokedexClientHttp", httpClient =>
{
   httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("PokedexClientHttp:BaseAddress").Value!);
});

builder.Services.AddAutoMapper(typeof(AssemblyMarker));
builder.Services.AddKafkaConsumerService<KafkaTopicsInput, MessageHandlerFactory>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Applico Migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PokemonTrainerServiceDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
