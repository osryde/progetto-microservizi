using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;
using PokedexService.Business;
using PokedexService.Business.Abstraction;
using PokemonCaptureService.Shared;

using System.Net.Http;

using System.Threading.Tasks;
using System.Threading;

namespace PokedexService.ClientHttp
{
    public class ClientHttp : IClientHttp
    {

        private readonly HttpClient _httpClient;

        public ClientHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5115");
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