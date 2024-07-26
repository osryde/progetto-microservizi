using Microsoft.Extensions.DependencyInjection;

namespace PokemonCaptureService.Business.Kafka{
    public class KafkaTopicsOutput : AbstractKafkaTopics {
        public static string Pokemon { get; set; } = "Pokemon";
        public static string Item { get; set; } = "Item";

        public override IEnumerable<string> GetTopics() => new List<string>() { Pokemon, Item };

    }
}