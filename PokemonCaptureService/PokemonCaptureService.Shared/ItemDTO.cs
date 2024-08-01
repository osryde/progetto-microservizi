using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCaptureService.Shared
{

    public class ItemDTO
    {
        
		public int ItemId { get; set; }

		public string ItemName { get; set; }

        public int  Quantity { get; set; }

    }
}