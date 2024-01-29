
namespace PokedexService.Repository.Model
{

    public class Pokemon
    {
        public int Id { get; set; }
        public int PokedexNum { get; set; }
        public string PokemonName { get; set; }
        public string Image { get; set; }
        public string[] PokemonType { get; set; }
        public string PokemonHeight { get; set; }
        public string PokemonWeight { get; set; }
        public string[] PokemonWeaknesses { get; set; }
        public int Id { get; set; }

        public Evolution[] Evolutions { get; set; }
    }

    public class Evolution
    {
        public int Id { get; set; }
        public int PokedexNum { get; set; }

    }
}