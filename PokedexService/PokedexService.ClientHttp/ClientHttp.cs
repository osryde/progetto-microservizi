using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;
using PokedexService.Business;
using PokedexService.Business.Abstraction;
using PokemonCaptureService.Shared;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

using System.Threading.Tasks;
using System.Threading;

namespace PokedexService.ClientHttp
{
    public class ClientHttp : IClientHttp
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ClientHttp(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["PokedexClientHttp:BaseAddress"] ?? throw new FileLoadException("BaseAddress not found in configuration"));
        }

        public async Task<PokemonDTO?> PokemonRandomAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"/Pokedex/PokemonRandom", cancellationToken);

            if (response == null)
            {
                throw new HttpRequestException("Errore durante la richiesta");
            }

            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<PokemonDTO>();
        }
    }
}