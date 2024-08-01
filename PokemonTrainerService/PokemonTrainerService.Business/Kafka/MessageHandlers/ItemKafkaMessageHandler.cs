using AutoMapper;
using PokemonTrainerService.Repository.Abstraction;
using PokemonTrainerService.Repository.Model;
using Microsoft.Extensions.Logging;
using PokemonCaptureService.Shared;

namespace PokemonTrainerService.Business.Kafka.MessageHandlers;

public class ItemKafkaMessageHandler : AbstractMessageHandler<ItemDTO, Items> {
    public ItemKafkaMessageHandler(ILogger<ItemKafkaMessageHandler> logger, IRepository repository, IMapper map) : base(logger, repository, map) { }

    protected override async Task InsertDtoAsync(Items domainDto, CancellationToken cancellationToken = default) {
        await Repository.AddItemsAsync(domainDto, cancellationToken);
    }
    protected override async Task UpdateDtoAsync(Items domainDto, CancellationToken cancellationToken = default) {
        // Non necessario
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
    protected override async Task DeleteDtoAsync(Items domainDto, CancellationToken cancellationToken = default)
    {
        // Non necessario
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
