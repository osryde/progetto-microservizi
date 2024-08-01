using PokemonCaptureService.Repository.Model;
using Microsoft.EntityFrameworkCore;
using PokemonCaptureService.Repository.Abstraction;



namespace PokemonCaptureService.Repository
{
    public class PokemonCaptureServiceDbContext : DbContext
    {

        public PokemonCaptureServiceDbContext(DbContextOptions<PokemonCaptureServiceDbContext> options) 
            : base(options) 
        {
            
        }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definisco le chiavi per le relazioni
            modelBuilder.Entity<Pokemon>().HasKey(x => x.PokemonId);

            modelBuilder.Entity<Items>().HasKey(y => y.ItemId);

            modelBuilder.Entity<TransactionalOutbox>().ToTable("TransactionalOutbox");
            modelBuilder.Entity<TransactionalOutbox>().HasKey(e => new { e.Id });
            
        }


        //DBSet ottenuto dalla cartella Model
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Items> Item { get; set; }
        public DbSet<TransactionalOutbox> TransactionalOutboxList { get; set; }

    }
}