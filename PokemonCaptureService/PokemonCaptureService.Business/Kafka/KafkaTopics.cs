using Microsoft.Extensions.DependencyInjection;

namespace PokemonCaptureService.Business.Kafka{
    public class KafkaTopicsOutput : AbstractKafkaTopics {
        public static string Pokemon { get; set; } = "Pokemon";
        public static string Items { get; set; } = "Items";

        public override IEnumerable<string> GetTopics() => new List<string>() { Pokemon, Items };

    }
}