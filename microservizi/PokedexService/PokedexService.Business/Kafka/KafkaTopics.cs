using Microsoft.Extensions.DependencyInjection;

namespace PokedexService.Business.Kafka;

public class KafkaTopicsInput : AbstractKafkaTopics {

    public string Pokemon { get; set; } = "Pokemon";

    public override IEnumerable<string> GetTopics() => new List<string>() { Pokemon };

}
