using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;
using PokedexService.Business;
using PokedexService.Business.Abstraction;
using PokedexService.Shared;

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
        }

        public async Task PokemonAddAsync(PokemonDTO pokemon, CancellationToken cancellationToken = default)
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5115");

            var response = await _httpClient.PostAsync($"/Pokedex/AddPokemonAsync", JsonContent.Create(pokemon));

            await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
    }
}