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
        public async Task<Items> AddItemsAsync(Items item, CancellationToken cancellationToken = default)
        {
            await _PokemonTrainerServiceDbContext.Items.AddAsync(item, cancellationToken);
            await _PokemonTrainerServiceDbContext.SaveChangesAsync(cancellationToken);
            return item;

        }

        public async Task<Items> GetItemById(int id, CancellationToken cancellationToken = default)
        {
            Items? result = await _PokemonTrainerServiceDbContext.Items.FirstOrDefaultAsync(x => x.ItemId == id, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale ID");

            return result;
        }

        public async Task<Items> GetItemByName(string name, CancellationToken cancellationToken = default)
        {
            Items? result = await _PokemonTrainerServiceDbContext.Items.FirstOrDefaultAsync(x => x.ItemName == name, cancellationToken);

            if (result == null)
                throw new NullReferenceException("Non è stato trovato un Item con tale NOME");

            return result;
        }

        public async Task<IEnumerable<Items>> GetAllItems(CancellationToken cancellationToken = default)
        {
            return await _PokemonTrainerServiceDbContext.Items.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Items>> RemoveAllItems(CancellationToken cancellationToken = default)
        {
            _PokemonTrainerServiceDbContext.Items.RemoveRange(_PokemonTrainerServiceDbContext.Items);
            await _PokemonTrainerServiceDbContext.SaveChangesAsync(cancellationToken);
            return await _PokemonTrainerServiceDbContext.Items.ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default){
            return await _PokemonTrainerServiceDbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
