using PokemonTrainerService.Repository.Model;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerService.Repository.Abstraction;



namespace PokemonTrainerService.Repository
{
    public class PokemonTrainerServiceDbContext : DbContext
    {

        //DBSet ottenuto dalla cartella Model
        public PokemonTrainerServiceDbContext(DbContextOptions<PokemonTrainerServiceDbContext> options) 
            : base(options) 
        {
        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(y => y.ItemId); // Chiave delle relazioni
        }

        public DbSet<Item> Item { get; set; }

    }
}