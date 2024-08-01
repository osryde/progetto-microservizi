using PokemonCaptureService.Repository;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokemonCaptureService.Repository
{

    public class Repository : IRepository 
    {
        private PokemonCaptureServiceDbContext _PokemonCaptureServiceDbContext;
        public Repository(PokemonCaptureServiceDbContext pokemonCaptureServiceDbContext)
        {
            _PokemonCaptureServiceDbContext = pokemonCaptureServiceDbContext;
        }

        #region PokemonGetter

        public async Task<Pokemon> GetPokemonById(int id, CancellationToken cancellationToken = default)
        {
            Pokemon? result = await _PokemonCaptureServiceDbContext.Pokemons.FirstOrDefaultAsync(x => x.PokemonId == id, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un pokemon con tale ID");

            return result;

        }

        public async Task<Pokemon> GetPokemonByName(string name, CancellationToken cancellationToken = default)
        {
            Pokemon? result = await _PokemonCaptureServiceDbContext.Pokemons.FirstOrDefaultAsync(x => x.PokemonName == name, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un pokemon con tale NOME");

            return result;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons(CancellationToken cancellationToken = default) => await _PokemonCaptureServiceDbContext.Pokemons.ToListAsync(cancellationToken);


        #endregion

        #region ItemsGetter

        public async Task<Items> GetItemById(int id, CancellationToken cancellationToken = default)
        {
            Items? result = await _PokemonCaptureServiceDbContext.Item.FirstOrDefaultAsync(x => x.ItemId == id, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale ID");

            return result;      
        }


        public async Task<Items> GetItemByName(string name, CancellationToken cancellationToken = default)
        {
            Items? result = await _PokemonCaptureServiceDbContext.Item.FirstOrDefaultAsync(x => x.ItemName == name, cancellationToken);

            if(result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale NOME");

            return result;              }

        public async Task<IEnumerable<Items>> GetAllItems(CancellationToken cancellationToken = default) => await _PokemonCaptureServiceDbContext.Item.ToListAsync(cancellationToken);


        #endregion

        #region Adder

        // Metodi per aggiungere all'interno della tabella
        public async Task<Pokemon> AddPokemonAsync(Pokemon pokemon, CancellationToken cancellationToken = default){
            if(pokemon == null)
                throw new NullReferenceException("Il pokemon passato è null");
           
            await _PokemonCaptureServiceDbContext.Pokemons.AddAsync(pokemon);

            return pokemon;
        }
        public async Task<Items> AddItemsAsync(Items items, CancellationToken cancellationToken = default){
            if(items == null)
                throw new NullReferenceException("L'Item passato è null");

            await _PokemonCaptureServiceDbContext.Item.AddAsync(items);

            return items;
        }

        public async Task AddPokemonsAndItemsAsync(CancellationToken cancellationToken = default){
             
            if(_PokemonCaptureServiceDbContext.Pokemons.Count() != 0 || _PokemonCaptureServiceDbContext.Item.Count() != 0)
                return;

            using FileStream dati = File.OpenRead("pokedexMinimal.json");
            
            var extractedDataPokemon = JsonSerializer.Deserialize<List<Pokemon>>(dati);

            if(extractedDataPokemon == null)
                throw new NullReferenceException("File json non trovato");

            foreach (Pokemon pokemon in extractedDataPokemon)
            {
                await AddPokemonAsync(pokemon, cancellationToken);
            }

            using FileStream dati2 = File.OpenRead("items.json");

            var extractedDataItems = JsonSerializer.Deserialize<List<Obj>>(dati2);

            if(extractedDataItems == null)
                throw new NullReferenceException("File json non trovato");

            foreach (Obj obj in extractedDataItems)
            {
                Items item = new()
                {
                    ItemId = obj.Id,
                    ItemName = obj.Name["english"]
                };

                await AddItemsAsync(item, cancellationToken);
            }
        }

        #endregion

        #region TransactionalOutbox
         public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) => await _PokemonCaptureServiceDbContext.TransactionalOutboxList.ToListAsync(cancellationToken);

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default)
        {
            return await _PokemonCaptureServiceDbContext.TransactionalOutboxList.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default)
        {
            _PokemonCaptureServiceDbContext.TransactionalOutboxList.Remove(
                (await GetTransactionalOutboxByKey(id, cancellationToken)) ??
                throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));
        }

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default)
        {
            await _PokemonCaptureServiceDbContext.TransactionalOutboxList.AddAsync(transactionalOutbox);
        }

        #endregion

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default){
            return await _PokemonCaptureServiceDbContext.SaveChangesAsync(cancellationToken);
        }

    }


    // Classi d'appoggio per convertire il json
    public class Obj
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required Dictionary<string, string> Name { get; set; } 
    }

    
    
}