using PokedexService.Repository.Model;

namespace PokedexService.Business.Abstraction
{
    public interface IBusiness
    {

        Task<IEnumerable<Pokemon>> PokedexAsync(CancellationToken cancellationToken = default);
        Task AggiungiPokemon(string name, CancellationToken cancellationToken = default);
        Task<Pokemon> RandomPokemon(CancellationToken cancellationToken = default);
        Task<int> PokemonMancanti(CancellationToken cancellationToken = default);
        Task ResetPokedexAsync(CancellationToken cancellationToken = default);
    }
    
}