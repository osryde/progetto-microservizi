using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Model;

namespace PokemonTrainerService.Business.Abstraction
{
    public interface IBusiness 
    {
        Task<IEnumerable<Items>> ListaZaino(CancellationToken cancellationToken = default);
        Task AggiungiOggetto(string name, CancellationToken cancellationToken = default);
        Task<string> CreaSquadraCasuale(CancellationToken cancellationToken = default);
        Task SvuotaZaino(CancellationToken cancellationToken = default);
    }
}