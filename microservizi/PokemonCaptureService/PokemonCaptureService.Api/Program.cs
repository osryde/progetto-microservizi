using PokemonCaptureService.Repository;
using Microsoft.EntityFrameworkCore;
using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Business;
using PokemonCaptureService.Repository.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<PokemonCaptureServiceDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PokemonCaptureServiceDbContext", b => b.MigrationsAssembly("PokemonCaptureService.Repository")));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();

// ClientHttp da contattare ( PokedexService )
builder.Services.AddHttpClient<PokedexService.ClientHttp.Abstraction.IClientHttp, PokedexService.ClientHttp.ClientHttp>("PokedexClientHttp", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("PokedexClientHttp:BaseAddress").Value!);
});

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
