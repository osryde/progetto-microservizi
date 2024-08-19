using Microsoft.AspNetCore.Mvc;
using PokemonTrainerService.Repository;
using PokemonTrainerService.Repository.Model;
using PokemonTrainerService.Business.Abstraction;

namespace PokemonTrainerService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonTrainerController : ControllerBase
{
   
   private readonly PokemonTrainerServiceDbContext dbContext;
    private readonly IBusiness _business;   

    public PokemonTrainerController(PokemonTrainerServiceDbContext dbContext, IBusiness business)
    {
        this.dbContext = dbContext;
        _business = business;
    }
    
    [HttpPost("Aggiungi Oggetto nella borsa")]
    public async Task<ActionResult> AddItemAsync(string? itemName, CancellationToken cancellationToken)
    {
            
        if(itemName == null)
            return Ok("Item non valido! ");
        
        try{
            await _business.AggiungiOggetto(itemName, cancellationToken);
            dbContext.SaveChanges();
        }catch(Exception e){    
            return BadRequest("L'item dato non è valido. Errore: " + e.Message);
        }

        return Ok("Item aggiunto nella Borsa!");
    
    }

    [HttpPost("Contenuto Zaino")]
    public async Task<ActionResult<string>> BorsaAsync(CancellationToken cancellationToken){
        var json = await _business.ListaZaino();
        string result = "";

        foreach(Items p in json)
        {
            result += "\n Id: " + p.ItemId  + " Name: " + p.ItemName + " - Quantità: " + p.Quantity;
        }

        if(result == "")
            return Ok("Zaino Vuoto!");

        return Ok(result);
    }

    [HttpGet("Svuota Zaino")]
    public async Task<ActionResult<string>> SvuotaBorsaAsync(CancellationToken cancellationToken){
        await _business.SvuotaZaino();
        return Ok("Zaino Svuotato!");
    }

    [HttpGet("Team Casuale")]
    public async Task<ActionResult<string>> TeamCasualeAsync(CancellationToken cancellationToken){
        return Ok(await _business.CreaSquadraCasuale());
    }
}
