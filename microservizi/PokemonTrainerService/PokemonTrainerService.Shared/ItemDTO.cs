using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonTrainerService.Shared
{

    public class ItemDTO
    {
        
		public int ItemId { get; set; }

		public required string ItemName { get; set; }

        public int  Quantity { get; set; }

    }
}