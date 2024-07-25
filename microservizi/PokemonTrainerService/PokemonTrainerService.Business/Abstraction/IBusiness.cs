using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Model;

namespace PokemonTrainerService.Business.Abstraction
{
    public interface IBusiness 
    {
        Task<IEnumerable<Item>> ListaZaino(CancellationToken cancellationToken = default);
        Task<Item> AggiungiOggetto(Item item, CancellationToken cancellationToken = default);
        Task<String> CreaSquadraCasuale(CancellationToken cancellationToken = default);

    }
}