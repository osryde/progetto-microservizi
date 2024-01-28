
using PokemonCaptureService.Repository;
using PokemonCaptureService.Repository.Model;

namespace PokemonCaptureService.Business.Abstract
{
    public interface IBusiness
    {

        Task<Pokemon> CatturaPokemon();
        Task<Items> OggettoCasuale();


    }

}