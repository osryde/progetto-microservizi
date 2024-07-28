using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PokemonTrainerService.Repository.Model
{
    public class Items
	{

		[JsonPropertyName("id")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ItemId { get; set; }

		[JsonPropertyName("name")]
		public string? ItemName { get; set; }

        public int  Quantity { get; set; }

    }
}