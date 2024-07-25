using PokemonTrainerService.Repository.Model;

namespace PokemonTrainerService.Repository.Abstraction
{
    public interface IRepository
    {
        Task<Item> AddItemsAsync(Item item, CancellationToken cancellationToken = default);

        Task<Item> GetItemById(int id, CancellationToken cancellationToken = default);

        Task<Item> GetItemByName(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<Item>> GetAllItems(CancellationToken cancellationToken = default);

        Task<IEnumerable<Item>> RemoveAllItems(CancellationToken cancellationToken = default);
    }
    
}