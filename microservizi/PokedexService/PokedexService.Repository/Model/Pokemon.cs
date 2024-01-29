using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexService.Repository.Model
{

    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("num")]
        public int PokedexNum { get; set; }

        [JsonPropertyName("name")]
        public required string PokemonName { get; set; }

        [JsonPropertyName("img")]
        public required string Image { get; set; }

        [JsonPropertyName("type")]
        public required string[] PokemonType { get; set; }

        [JsonPropertyName("height")]
        public required string PokemonHeight { get; set; }

        [JsonPropertyName("weight")]
        public required string PokemonWeight { get; set; }

        [JsonPropertyName("weaknesses")]
        public required string[] PokemonWeaknesses { get; set; }

        [JsonPropertyName("next_evolution")]
        public Evolution[]? Evolutions { get; set; }
    }

    public class Evolution
    {
        public int Id { get; set; }
        public int PokedexNum { get; set; }

    }
}