using Microsoft.AspNetCore.Mvc;
using PokedexService.Repository.Model;
using PokedexService.Business.Abstraction;
using PokedexService.Repository;
using PokemonCaptureService.Shared;
using AutoMapper;

namespace PokedexService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokedexController : ControllerBase
{

    private readonly PokedexServiceDbContext dbContext;
    private readonly IBusiness _business;   
    private readonly IMapper _mapper;

    public PokedexController(PokedexServiceDbContext dbContext, IBusiness business, IMapper mapper)
    {
        this.dbContext = dbContext;
        _business = business;
        _mapper = mapper;
    }
    
    [HttpPost("Add Pokemon")]
    public async Task<ActionResult> AddPokemonAsync(string? pokemonName, CancellationToken cancellationToken)
    {
            
        if(pokemonName == null)
            return Ok("Pokemon non valido! ");
        
        try{
            await _business.AggiungiPokemon(pokemonName, cancellationToken);
        }catch(Exception e){
            return BadRequest("Pokemon non valido! " + e.Message);
        }

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
    public async Task<ActionResult<string>> ResetPokedexAsync(CancellationToken cancellationToken) {
        await _business.ResetPokedexAsync();
        return Ok("Pokedex resettato!");
    }


    [HttpGet("PokemonRandom")]
    public async Task<ActionResult<PokemonDTO>> PokemonRandomAsync(CancellationToken cancellationToken) {
        PokemonDTO pokemon = _mapper.Map<PokemonDTO>(await _business.RandomPokemon());
        return Ok(pokemon);
    }

    [HttpGet("PokemonMancanti")]
    public async Task<ActionResult<Pokemon>> PokemonMancantiAsync(CancellationToken cancellationToken) {
        return Ok("Attualmente ti restano <" + await _business.PokemonMancanti() + "> pokemon da catturare! \nNon mollare!");
    }

}
