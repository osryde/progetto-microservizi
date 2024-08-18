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
    private readonly HttpClient _httpClient;

    public PokemonPopulateController(PokemonCaptureServiceDbContext dbContext, IBusiness business, HttpClient httpClient)
    {
        this.dbContext = dbContext;
        _business = business;
        _httpClient = httpClient;
    }

    [HttpGet("Visualizza e Cattura Pokemon")]
    public async Task<IActionResult> PokemonCasualeImage(){
        // URL dell'immagine
        string imageUrl = (await _business.CatturaPokemon()).PokemonImage;

        // Scarica l'immagine dal URL
        byte[] imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

        // Restituisci l'immagine come FileContentResult
        return File(imageBytes, "image/png");
    }

    [HttpPost("Cattura Pokemon e Oggetti")]
    public async Task<IActionResult> PokemonCasuale(){
        
        Pokemon pokemon;
        Items? item;
        String result = "";
        Random random = new();
        
        if(random.Next()%2 == 0){
            result += "Il Pokemon è fuggito! ";
            return Ok(result);
        }

        try{
            pokemon = await _business.CatturaPokemon();
        }catch(Exception e){
            return BadRequest("Devi popolare l'area con i Pokémon prima di catturarne uno! oppure " + e.Message);
        }    

        if(random.Next()%2 == 0){
            try{
                item = await _business.OggettoCasuale();
            }catch(Exception e){
                return BadRequest("Devi riempire la zona con gli oggetti prima di poterne trovare uno! oppure " + e.Message);
            }
            result += "Hai trovato un oggetto: \nID -> " + item.ItemId + "\nNome -> " + item.ItemName;
        }

        return Ok(result + "\nPokemon trovato:\nID -> " + pokemon.PokemonId + "\nNome -> " + pokemon.PokemonName + $"\nPokemon Image -> {pokemon.PokemonImage}");

    }

    // TODO: Fare in modo che venga popolato con 10 pokemon e debba essere chiamato ogni volta che finiscono i pokemon
    [HttpPost("PopulateAreaWithPokemon")]
    public async Task<IActionResult> ImportPokemonFromJsonFile()
    {

        
            IRepository repo = new Repository(dbContext);
            
            await repo.AddPokemonsAndItemsAsync();

            await dbContext.SaveChangesAsync();

            return Ok("Dati Pokémon importati e salvati nel database con successo!");
        
        
    }


}