using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCaptureService.Shared
{

    public class PokemonDTO
    {
        
        public int PokemonId { get; set; }
        public string PokemonName { get; set; }
        public string PokemonImage { get; set; }

    }
}