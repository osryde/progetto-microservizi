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
    public async Task<ActionResult> AddItemAsync(Items? item, CancellationToken cancellationToken)
    {
            
        if(item == null || item.ItemName == null)
            return Ok("Item non valido! ");
        
        await _business.AggiungiOggetto(item.ItemName, cancellationToken);
        dbContext.SaveChanges();

        return Ok("Item aggiunto nella Borsa!");
    
    }

    [HttpPost("Contenuto Zaino")]
    public async Task<ActionResult<string>> BorsaAsync(CancellationToken cancellationToken){
        var json = await _business.ListaZaino();
        string result = "";

        foreach(Items p in json)
        {
            result += "\nName: " + p.ItemName + " - Quantità: " + p.Quantity;
        }

        return Ok(result);
    }
}
