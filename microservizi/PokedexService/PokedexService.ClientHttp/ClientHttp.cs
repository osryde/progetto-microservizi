using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Repository.Model;
using System.Net.Http.Json;
using PokedexService.Business;
using PokedexService.Business.Abstraction;


namespace PokedexService.ClientHttp
{
    public class ClientHttp : IClientHttp
    {

        private readonly HttpClient _httpClient;
        private IBusiness _business;
        public ClientHttp(HttpClient httpClient, IBusiness business)
        {
            _httpClient = httpClient;
            _business = business;
        }

        public async Task PokemonAddAsync(string name, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync($"/api/PokemonPopulate/PokemonAdd", JsonContent.Create(name));
            PokemonCaptureService.Repository.Model.Pokemon? value = await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<PokemonCaptureService.Repository.Model.Pokemon>(cancellationToken: cancellationToken);
        
        }
    }
}