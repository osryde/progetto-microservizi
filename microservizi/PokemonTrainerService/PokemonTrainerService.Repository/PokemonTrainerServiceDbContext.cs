using PokemonTrainerService.Repository.Model;
using Microsoft.EntityFrameworkCore;




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
            //Definisco le chiavi per le relazioni
        }

    }
}