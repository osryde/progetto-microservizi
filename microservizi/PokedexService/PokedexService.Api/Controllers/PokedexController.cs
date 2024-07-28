using Microsoft.AspNetCore.Mvc;
using PokedexService.Repository.Model;
using PokedexService.Business.Abstraction;
using PokedexService.Repository;
using PokemonCaptureService.Shared;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;

namespace PokedexService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokedexController : ControllerBase
{

    private readonly PokedexServiceDbContext dbContext;
    private readonly IBusiness _business;   

    public PokedexController(PokedexServiceDbContext dbContext, IBusiness business)
    {
        this.dbContext = dbContext;
        _business = business;
    }
    
    [HttpPost("AddPokemonAsync")]
    public async Task<ActionResult> AddPokemonAsync(PokemonDTO name, CancellationToken cancellationToken)
    {
            
        if(name == null)
            return Ok("Pokemon non valido! ");
        
        await _business.AggiungiPokemon(name.PokemonName, cancellationToken);
        dbContext.SaveChanges();

        return Ok("Pokemon aggiunto (Se non lo era gia!)");
    
    }

    [HttpPost("ListPokemon")]
    public async Task<ActionResult<string>> PokedexAsync(CancellationToken cancellationToken){
        var json = await _business.PokedexAsync();
        string result = "";

        foreach(Pokemon p in json)
        {
            result += "\nName: " + p.PokemonName + " Pokedex Number: " + p.PokemonId;
        }

        return Ok(result);
    }

    [HttpGet("Pokedex Reset")]
    public async Task<ActionResult<string>> ResetPokedexAsync() {
        await _business.ResetPokedexAsync();
        return Ok("Pokedex resettato!");
    }


    [HttpGet("PokemonRandom")]
    public async Task<ActionResult<Pokemon>> PokemonRandomAsync() {
        return Ok(await _business.RandomPokemon());
    }

}
