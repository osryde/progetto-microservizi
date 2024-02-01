using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;
using PokedexService.Business;
using PokedexService.Business.Abstraction;
using PokedexService.Shared;

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
            var response = await _httpClient.PostAsync($"/Pokedex/AddPokemonAsync", JsonContent.Create(pokemon.PokemonName));
            await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<string>(cancellationToken: cancellationToken);
        
        }
    }
}