using PokedexService.Business.Abstraction;
using PokedexService.Repository.Abstraction;
using PokedexService.Repository.Model;
using System.Text.Json;




namespace PokedexService.Business
{
    public class Business : IBusiness
    {

        private IRepository repo;
        
        public Business(IRepository repository)
        {
            repo = repository;
        }

        //Ritorno tutti i pokemon catturati presenti nel DB
        public async Task<IEnumerable<Pokemon>> PokedexAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Pokemon> pokemons = await repo.GetAllPokemons();

            return pokemons;
        }

        public async Task ResetPokedexAsync(CancellationToken cancellationToken = default)
        {
            await repo.DropPokedexAsync(cancellationToken);
        }

        public async Task<Pokemon> RandomPokemon(CancellationToken cancellationToken = default)
        {
            return await repo.GetRandomPokemonAsync(cancellationToken);
        }

        public async Task<int> PokemonMancanti(CancellationToken cancellationToken = default)
        {
            return 151 - (await repo.GetAllPokemons(cancellationToken)).Count();
        }

        public async Task AggiungiPokemon(string name, CancellationToken cancellationToken = default)
        {

            using FileStream dati = File.OpenRead("pokedexMinimal.json");
            
            // Controllo se il pokemon dato è valido
            var extractedDataPokemon = JsonSerializer.Deserialize<List<Pokemon>>(dati);

            if(extractedDataPokemon == null)
                throw new NullReferenceException("File json non trovato");

            try
            {

                await repo.GetPokemonByNameAsync(name, cancellationToken);

            }catch(Exception){

                foreach (Pokemon pokemon in extractedDataPokemon)
                {
                    if(pokemon.PokemonName == name)
                    {
                        await repo.AddPokemonAsync(pokemon, cancellationToken);
                        return;
                    }
                }
                throw new NullReferenceException("Pokemon non trovato nel file json");
            }

        }
    }
    
}

