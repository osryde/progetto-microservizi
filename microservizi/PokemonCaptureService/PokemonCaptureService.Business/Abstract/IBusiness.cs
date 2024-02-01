
using PokemonCaptureService.Repository;
using PokemonCaptureService.Repository.Model;


namespace PokemonCaptureService.Business.Abstract
{
    public interface IBusiness
    {

        Task<Pokemon> CatturaPokemon(CancellationToken cancellationToken = default);
        Task<Items> OggettoCasuale(CancellationToken cancellationToken = default);


    }

}