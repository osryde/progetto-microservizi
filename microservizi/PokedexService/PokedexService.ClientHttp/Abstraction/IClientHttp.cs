
namespace PokedexService.ClientHttp.Abstraction
{
    public interface IClientHttp
    {
        Task PokemonAddAsync(string name, CancellationToken cancellationToken = default);
    }
}