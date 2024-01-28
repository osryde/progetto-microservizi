using PokemonCaptureService.Repository.Model;
using Microsoft.EntityFrameworkCore;
using PokemonCaptureService.Repository.Abstraction;



namespace PokemonCaptureService.Repository
{
    public class PokemonCaptureServiceDbContext : DbContext
    {

        //DBSet ottenuto dalla cartella Model
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Items> Items { get; set; }

        public PokemonCaptureServiceDbContext(DbContextOptions<PokemonCaptureServiceDbContext> options) 
            : base(options) 
        {
            
        }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definisco le chiavi per le relazioni
            modelBuilder.Entity<Pokemon>().HasKey(x => x.PokemonId);

            modelBuilder.Entity<Items>().HasKey(y => y.ItemId);
            
        }

    }
}