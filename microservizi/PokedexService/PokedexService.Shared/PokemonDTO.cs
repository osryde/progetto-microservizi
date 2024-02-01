using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexService.Shared
{

    public class PokemonDTO
    {
        
        public int Id { get; set; }
        public required string PokemonName { get; set; }
        public required string Image { get; set; }

    }
}