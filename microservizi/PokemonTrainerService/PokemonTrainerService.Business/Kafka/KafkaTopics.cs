using Microsoft.Extensions.DependencyInjection;
using Utility.Kafka;

namespace PokedexService.Business.Kafka;

public class KafkaTopicsInput : AbstractKafkaTopics {

    public string Items { get; set; } = "Items";

    public override IEnumerable<string> GetTopics() => new List<string>() { Items };

}
