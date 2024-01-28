using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;

namespace PokemonCaptureService.Business
{

    public class Business : IBusiness
    {

        private IRepository repo;

        public Business(IRepository repository)
        {
            repo = repository;
        }

        public async Task<Pokemon> CatturaPokemon()
        {
            Random random = new();
            var casualId = random.Next(1,152);
            return await repo.GetPokemonById(casualId);
        }

        public async Task<Items> OggettoCasuale()
        {
            Random random = new();
            var casualId = random.Next(1,897);
            return await repo.GetItemById(casualId);
        }
    }


}

