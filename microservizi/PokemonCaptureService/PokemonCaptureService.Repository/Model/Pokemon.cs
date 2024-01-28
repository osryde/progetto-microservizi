using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;


namespace PokemonCaptureService.Repository.Model
{
    public class Pokemon 
    {

        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PokemonId { get; set; }

        // Required indica che non può essere null

        [JsonPropertyName("name")]
        public required String PokemonName { get; set; }
        
        [JsonPropertyName("img")]
        public required String PokemonImage { get; set; }
    }


}

