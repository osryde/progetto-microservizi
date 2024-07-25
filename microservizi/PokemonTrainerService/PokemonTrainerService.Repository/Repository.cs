using PokemonTrainerService.Repository.Abstraction;
using PokemonTrainerService.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PokemonTrainerService.Repository
{
    public class Repository : IRepository
    {
        private PokemonTrainerServiceDbContext _PokemonTrainerServiceDbContext;
        public Repository(PokemonTrainerServiceDbContext pokemonTrainerServiceDbContext)
        {
            _PokemonTrainerServiceDbContext = pokemonTrainerServiceDbContext;
        }
        public async Task<Item> AddItemsAsync(Item item, CancellationToken cancellationToken = default)
        {
            await _PokemonTrainerServiceDbContext.Item.AddAsync(item, cancellationToken);
            await _PokemonTrainerServiceDbContext.SaveChangesAsync(cancellationToken);
            return item;

        }

        public async Task<Item> GetItemById(int id, CancellationToken cancellationToken = default)
        {
            Item? result = await _PokemonTrainerServiceDbContext.Item.FirstOrDefaultAsync(x => x.ItemId == id, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale ID");

            return result;
        }

        public async Task<Item> GetItemByName(string name, CancellationToken cancellationToken = default)
        {
            Item? result = await _PokemonTrainerServiceDbContext.Item.FirstOrDefaultAsync(x => x.ItemName == name, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale NOME");

            return result;
        }

        public async Task<IEnumerable<Item>> GetAllItems(CancellationToken cancellationToken = default)
        {
            return await _PokemonTrainerServiceDbContext.Item.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Item>> RemoveAllItems(CancellationToken cancellationToken = default)
        {
            _PokemonTrainerServiceDbContext.Item.RemoveRange(_PokemonTrainerServiceDbContext.Item);
            await _PokemonTrainerServiceDbContext.SaveChangesAsync(cancellationToken);
            return await _PokemonTrainerServiceDbContext.Item.ToListAsync(cancellationToken);
        }
    }

}
