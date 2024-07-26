using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCaptureService.Shared
{

    public class PokemonDTO
    {
        
        public int Id { get; set; }
        public string PokemonName { get; set; }
        public string Image { get; set; }

    }
}