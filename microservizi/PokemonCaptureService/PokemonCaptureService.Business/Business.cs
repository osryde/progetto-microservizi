using System.Text.Json;
using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Shared;

namespace PokemonCaptureService.Business
{

    public class Business : IBusiness
    {

        private IRepository repo;
        public Business(IRepository repository)
        {
            repo = repository;
        }

        public async Task<Pokemon> CatturaPokemon(CancellationToken cancellationToken = default)
        {
            Random random = new();
            var casualId = random.Next(1,152);
            Pokemon result = await repo.GetPokemonById(casualId);
            PokemonDTO tmp = new PokemonDTO{
                PokemonName = result.PokemonName,
                Id = result.PokemonId,
                Image = result.PokemonImage
            };

            //Implementare comunicazione con kafka

            return result;
        }

        public async Task<Items> OggettoCasuale(CancellationToken cancellationToken = default)
        {
            Random random = new();
            var casualId = random.Next(1,897);
            return await repo.GetItemById(casualId);
        }

        // TODO: PopulateAreaWithPokemon solo 10 che decrementano ad ogni cattura di un pokemon
    }


}

