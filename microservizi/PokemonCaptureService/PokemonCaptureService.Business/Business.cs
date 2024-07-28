using System.Text.Json;
using PokemonCaptureService.Business.Abstract;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Shared;
using PokemonCaptureService.Business.Factory;
using AutoMapper;

namespace PokemonCaptureService.Business
{

    public class Business : IBusiness
    {

        private readonly IMapper _mapper;
        private IRepository repo;
        public Business(IRepository repository, IMapper mapper)
        {
            repo = repository;
            _mapper = mapper;
        }

        public async Task<Pokemon> CatturaPokemon(CancellationToken cancellationToken = default)
        {
            Random random = new();
            var casualId = random.Next(1,152);
            Pokemon result = await repo.GetPokemonById(casualId);
            PokemonDTO newPokemon = _mapper.Map<PokemonDTO>(result); // Da record a DTO

            await repo.InsertTransactionalOutbox(TransactionalOutboxFactory.CreateInsert(newPokemon), cancellationToken);
            await repo.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<Items> OggettoCasuale(CancellationToken cancellationToken = default)
        {
            // Implementare comunicazione con kafka
            Random random = new();
            var casualId = random.Next(1,897);
            Items item = await repo.GetItemById(casualId);

            ItemDTO newItem = _mapper.Map<ItemDTO>(item); // Da record a DTO

            await repo.InsertTransactionalOutbox(TransactionalOutboxFactory.CreateInsert(newItem), cancellationToken);
            await repo.SaveChangesAsync(cancellationToken);

            return item;
        }

        // TODO: PopulateAreaWithPokemon solo 10 che decrementano ad ogni cattura di un pokemon
    }


}

