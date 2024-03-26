using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;


namespace PokemonCaptureService.Business
{

    public class Business : IBusiness
    {

        private IRepository repo;
        private readonly PokedexService.ClientHttp.Abstraction.IClientHttp _clientHttp;
        public Business(IRepository repository, PokedexService.ClientHttp.Abstraction.IClientHttp clientHttp)
        {
            repo = repository;
            _clientHttp = clientHttp;
        }

        public async Task<Pokemon> CatturaPokemon(CancellationToken cancellationToken = default)
        {
            Random random = new();
            var casualId = random.Next(1,152);
            Pokemon result = await repo.GetPokemonById(casualId);
            PokedexService.Shared.PokemonDTO tmp = new PokedexService.Shared.PokemonDTO{
                PokemonName = result.PokemonName,
                Id = result.PokemonId,
                Image = result.PokemonImage
            };
            await _clientHttp.PokemonAddAsync(tmp, cancellationToken);

            return result;
        }

        public async Task<Items> OggettoCasuale(CancellationToken cancellationToken = default)
        {
            Random random = new();
            var casualId = random.Next(1,897);
            return await repo.GetItemById(casualId);
        }

        #TODO: PopulateAreaWithPokemon solo 10 che decrementano ad ogni cattura di un pokemon
    }


}

