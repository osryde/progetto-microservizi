using PokedexService.Repository.Model;

namespace PokedexService.Business.Abstraction
{
    public interface IBusiness
    {

        Task<IEnumerable<Pokemon>> PokedexAsync(CancellationToken cancellationToken = default);
        Task AggiungiPokemon(string name, CancellationToken cancellationToken = default);
        void ResetPokedexAsync(CancellationToken cancellationToken = default);
    }
    
}