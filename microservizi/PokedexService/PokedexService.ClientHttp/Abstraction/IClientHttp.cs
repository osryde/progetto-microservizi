using PokedexService.Shared;
namespace PokedexService.ClientHttp.Abstraction
{
    public interface IClientHttp
    {
        Task PokemonAddAsync(PokemonDTO pokemon, CancellationToken cancellationToken = default);
    }
}