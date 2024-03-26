using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PokemonCaptureService.Repository;
using PokemonCaptureService.Repository.Abstraction;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Business.Abstract;


[ApiController]
[Route("api/[controller]")]
public class PokemonPopulateController : ControllerBase
{
    private readonly PokemonCaptureServiceDbContext dbContext;
    private readonly IBusiness _business;   

    public PokemonPopulateController(PokemonCaptureServiceDbContext dbContext, IBusiness business)
    {
        this.dbContext = dbContext;
        _business = business;
    }

    [HttpPost("PokemonCasuale")]
    public async Task<IActionResult> PokemonCasuale(){
        
        String result = "";
        Pokemon pokemon = await _business.CatturaPokemon();
        Random random = new();

        Items? item = null;
        if(random.Next()%20 == 0)
            item = await _business.OggettoCasuale();
        
        if(item != null){
            result += "Hai trovato un oggetto: \nID -> " + item.ItemId + "\nNome -> " + item.ItemName;
        }

        return Ok(result + "\nPokemon trovato:\nID -> " + pokemon.PokemonId + "\nNome -> " + pokemon.PokemonName + "\nImmagine -> " + pokemon.PokemonImage);

    }

    #TODO: Fare in modo che venga popolato con 10 pokemon e debba essere chiamato ogni volta che finiscono i pokemon
    [HttpPost("PopulateAreaWithPokemon")]
    public async Task<IActionResult> ImportPokemonFromJsonFile()
    {

        
            IRepository repo = new Repository(dbContext);
            
            await repo.AddPokemonsAndItemsAsync();

            await dbContext.SaveChangesAsync();

            return Ok("Dati Pokémon importati e salvati nel database con successo!");
        
        
    }


}