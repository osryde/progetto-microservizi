using PokemonTrainerService.ClientHttp.Abstraction;
using System.Net.Http.Json;

namespace PokemonTrainerService.ClientHttp
{
    public class ClientHttp : IClientHttp
    {
        private readonly HttpClient _httpClient;
        public ClientHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
    }
}
