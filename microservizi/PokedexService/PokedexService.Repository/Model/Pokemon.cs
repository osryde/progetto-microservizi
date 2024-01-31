using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexService.Repository.Model
{

    public class Pokemon
    {
        [JsonPropertyName("id")]
        
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string PokemonName { get; set; }

        [JsonPropertyName("img")]
        public required string Image { get; set; }

    }

    public class Evolution
    {
        public int Id { get; set; }
        public int PokedexNum { get; set; }

    }
}