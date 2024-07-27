using PokemonTrainerService.Repository.Model;

namespace PokemonTrainerService.Repository.Abstraction
{
    public interface IRepository
    {
        Task<Items> AddItemsAsync(Items item, CancellationToken cancellationToken = default);

        Task<Items> GetItemById(int id, CancellationToken cancellationToken = default);

        Task<Items> GetItemByName(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<Items>> GetAllItems(CancellationToken cancellationToken = default);

        Task<IEnumerable<Items>> RemoveAllItems(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    
}