using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PokemonTrainerService.Repository.Model
{
    public class Item
	{

		[JsonPropertyName("id")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ItemId { get; set; }

		[JsonPropertyName("name")]
		public required string ItemName { get; set; }

        public int  Quantity { get; set; }
        
    }
}