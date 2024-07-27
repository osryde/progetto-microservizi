using PokedexService.Repository.Abstraction;
using PokedexService.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace PokedexService.Repository
{
    public class Repository : IRepository
    {

        private PokedexServiceDbContext _PokedexServiceDbContext;
        public Repository(PokedexServiceDbContext pokedexServiceDbContext)
        {
            _PokedexServiceDbContext = pokedexServiceDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default){
            return await _PokedexServiceDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddPokemonAsync(Pokemon pokemon, CancellationToken cancellationToken = default)
        {
            if(pokemon == null)
                throw new NullReferenceException();

            await _PokedexServiceDbContext.Pokemons.AddAsync(pokemon, cancellationToken);
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            Pokemon? result = await _PokedexServiceDbContext.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id, cancellationToken);

            if(result == null)
                throw new NullReferenceException();

            // Il risultato può essere null
            return result;
        }

        public async Task<Pokemon> GetPokemonByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            Pokemon? result = await _PokedexServiceDbContext.Pokemons.FirstOrDefaultAsync(x => x.PokemonName == name, cancellationToken);

            if(result == default)
                throw new NullReferenceException();
                
            // Il risultato può essere null
            return result;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons(CancellationToken cancellationToken = default) => await _PokedexServiceDbContext.Pokemons.ToListAsync(cancellationToken);

        // RemovePokemonAsync non è implementato FATTO DA COPILOT 
        public async Task RemovePokemonAsync(int id, CancellationToken cancellationToken = default)
        {
            Pokemon? pokemon = await _PokedexServiceDbContext.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id, cancellationToken);

            if(pokemon == null)
                throw new NullReferenceException();

            _PokedexServiceDbContext.Pokemons.Remove(pokemon);
        }
    }
    
}

