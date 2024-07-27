using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Model;

namespace PokemonTrainerService.Business.Abstraction
{
    public interface IBusiness 
    {
        Task<IEnumerable<Items>> ListaZaino(CancellationToken cancellationToken = default);
        Task AggiungiOggetto(String name, CancellationToken cancellationToken = default);
        Task<String> CreaSquadraCasuale(CancellationToken cancellationToken = default);

    }
}