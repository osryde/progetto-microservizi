using PokedexService.Repository.Model;

namespace PokedexService.Repository.Abstraction
{
    public interface IRepository
    {
        
        Task AddPokemonAsync(Pokemon pokemon, CancellationToken cancellationToken = default);
        Task<Pokemon> GetPokemonByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Pokemon> GetPokemonByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Pokemon> GetRandomPokemonAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Pokemon>> GetAllPokemons(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Pokemon>> DropPokedexAsync(CancellationToken cancellationToken = default);

    }
}