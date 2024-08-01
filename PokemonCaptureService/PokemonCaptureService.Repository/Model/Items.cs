using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace PokemonCaptureService.Repository.Model
{
    


    public class Items 
    {

        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        [JsonPropertyName("name")]
        public required string ItemName { get; set; }

    }
    
}