using PokemonCaptureService.Shared;

namespace PokedexService.ClientHttp.Abstraction
{
    public interface IClientHttp
    {
        Task<PokemonDTO?> PokemonRandomAsync(CancellationToken cancellationToken = default);
    }
}