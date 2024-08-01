using PokemonCaptureService.Repository.Model;

namespace PokemonCaptureService.Repository.Abstraction
{
    public interface IRepository 
    {
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<Pokemon> AddPokemonAsync(Pokemon pokemon, CancellationToken cancellationToken = default);
        Task<Items> AddItemsAsync(Items items, CancellationToken cancellationToken = default);

        Task AddPokemonsAndItemsAsync(CancellationToken cancellationToken = default);
        Task<Pokemon> GetPokemonById(int id, CancellationToken cancellationToken = default);

        Task<Pokemon> GetPokemonByName(string name, CancellationToken cancellationToken = default);

        Task<Items> GetItemById(int id, CancellationToken cancellationToken = default);

        Task<Items> GetItemByName(string name, CancellationToken cancellationToken = default);

        Task<IEnumerable<Pokemon>> GetAllPokemons(CancellationToken cancellationToken = default);

        Task<IEnumerable<Items>> GetAllItems(CancellationToken cancellationToken = default);

        #region TransactionalOutbox

        Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);

        Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);

        Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);

        Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);

        #endregion
        
    }
}