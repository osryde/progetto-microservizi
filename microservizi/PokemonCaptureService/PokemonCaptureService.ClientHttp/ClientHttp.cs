using PokemonCaptureService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;

namespace PokemonCaptureService.ClientHttp
{
    public class ClientHttp : IClientHttp
    {
        private readonly HttpClient _httpClient;
        public ClientHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> PokemonCasualeAsync(CancellationToken cancellationToken = default)
        {
           var response = await _httpClient.GetAsync($"/api/PokemonPopulate/PokemonCasuale");
           Pokemon? value = await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<Pokemon>(cancellationToken: cancellationToken);
           
           if(value == null)
            throw new NullReferenceException();

           return value.PokemonName;
        }
    }
}

