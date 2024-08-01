using AutoMapper;
using PokedexService.Repository.Abstraction;
using PokedexService.Repository.Model;
using Microsoft.Extensions.Logging;
using PokedexService.Business.Kafka.MessageHandlers;
using PokemonCaptureService.Shared;

namespace PokedexService.Business.Kafka.MessageHandlers;

public class PokemonKafkaMessageHandler : AbstractMessageHandler<PokemonDTO, Pokemon> {
    public PokemonKafkaMessageHandler(ILogger<PokemonKafkaMessageHandler> logger, IRepository repository, IMapper map) : base(logger, repository, map) { }

    protected override async Task InsertDtoAsync(Pokemon domainDto, CancellationToken cancellationToken = default) {
        await Repository.AddPokemonAsync(domainDto, cancellationToken);
    }
    protected override async Task UpdateDtoAsync(Pokemon domainDto, CancellationToken cancellationToken = default) {
        // Non necessario
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
    protected override async Task DeleteDtoAsync(Pokemon domainDto, CancellationToken cancellationToken = default)
    {
        // Non necessario
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
