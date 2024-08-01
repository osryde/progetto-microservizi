using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexService.Repository.Model
{

    public class Pokemon
    {
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PokemonId { get; set; }

        [JsonPropertyName("name")]
        public string? PokemonName { get; set; }

        [JsonPropertyName("img")]
        public string? PokemonImage { get; set; }

    }

}