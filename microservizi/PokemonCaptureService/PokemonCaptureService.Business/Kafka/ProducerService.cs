using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Utility.Kafka.Services;
using Utility.Kafka.Abstractions.Clients;
using PokemonCaptureService.Business.Kafka;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;
namespace UsersHandler.Business.Kafka;
public class ProducerService : ProducerService<KafkaTopicsOutput> {
	public ProducerService(
	ILogger<ProducerService<KafkaTopicsOutput>> logger,
	IProducerClient producerClient,
	IAdministatorClient administratorClient,
	IOptions<KafkaTopicsOutput> optionsTopics,
	IOptions<KafkaProducerServiceOptions> optionsProducerService,
	IServiceScopeFactory serviceScopeFactory)
	: base(logger, producerClient, administratorClient, optionsTopics, optionsProducerService, serviceScopeFactory) {

	}

	// usa `producerClient` per mandare messaggi a Kafka 
	protected override async Task OperationsAsync(CancellationToken cancellationToken) {
		using IServiceScope scope = ServiceScopeFactory.CreateScope();
		IRepository repository = scope.ServiceProvider.GetRequiredService<IRepository>();

		IEnumerable<TransactionalOutbox> transactions = await repository.GetAllTransactionalOutbox(cancellationToken);
		if (!transactions.Any()) {
			Logger.LogInformation("OperationsAsync: no transactions to manage");
			return;
		}

        

		try {

			foreach (TransactionalOutbox t in transactions) {
				string topic = t.Tabella;

                if (!topic.Equals(KafkaTopicsOutput.Pokemon) || !topic.Equals(KafkaTopicsOutput.Item))
			        throw new Exception($"OperationsAsync: topic <{topic}> is not permitted for this producer.");

				Logger.LogInformation("Message producing...");
				await ProducerClient.ProduceAsync(t.Tabella, t.Messaggio, cancellationToken);
				Logger.LogInformation("Message produced... deleting");

				await repository.DeleteTransactionalOutbox(t.Id, cancellationToken);
				Logger.LogInformation("DeleteTransactionalOutboxFromId done");

				await repository.SaveChangesAsync(cancellationToken);
				Logger.LogInformation("SaveChangesAsync done");

				string groupMsg = $"record {nameof(TransactionalOutbox)} con " +
					$"{nameof(TransactionalOutbox.Id)} = {t.Id}, " +
					$"{nameof(TransactionalOutbox.Tabella)} = '{t.Tabella}' e " +
					$"{nameof(TransactionalOutbox.Messaggio)} = '{t.Messaggio}'";

				Logger.LogInformation("Deleted {groupMsg}...", groupMsg);
			}

		} catch (Exception e) {
			throw new Exception("Error in ProducerService.OperationsAsync", e);
		}

		await Task.CompletedTask;
	}
}