using PokedexService.Repository.Model;
using Microsoft.EntityFrameworkCore;
using PokedexService.Repository.Abstraction;



namespace PokedexService.Repository
{
    public class PokedexServiceDbContext : DbContext
    {

        //DBSet ottenuto dalla cartella Model
        public DbSet<Pokemon> Pokemons { get; set; }

        public PokedexServiceDbContext(DbContextOptions<PokedexServiceDbContext> options) 
            : base(options) 
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definisco le chiavi per le relazioni
            modelBuilder.Entity<Pokemon>().HasKey(x => x.PokemonId);
            
        }

    }
}