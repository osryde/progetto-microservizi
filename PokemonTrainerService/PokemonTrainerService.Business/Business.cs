using PokemonTrainerService.Business.Abstraction;
using PokemonTrainerService.Repository.Model;
using PokemonTrainerService.Repository.Abstraction;
using System.Text.Json;
using PokedexService.ClientHttp.Abstraction;
using PokemonCaptureService.Shared;

namespace PokemonTrainerService.Business
{
    public class Business : IBusiness
    {   

        private IRepository repo;
        private IClientHttp _clientHttp;
        
        public Business(IRepository repository, IClientHttp clientHttp)
        {
            repo = repository;
            _clientHttp = clientHttp;
        }

        public async Task<IEnumerable<Items>> ListaZaino(CancellationToken cancellationToken = default)
        {
            IEnumerable<Items> items = await repo.GetAllItems();
            return items;
        }
        public async Task AggiungiOggetto(string? name, CancellationToken cancellationToken = default)
        {

            // Apro il file json
            using FileStream dati = File.OpenRead("items.json");
            
            // Controllo se l'item dato è valido
            var extractedDataItem = JsonSerializer.Deserialize<List<Items>>(dati);

            if(extractedDataItem == null || name == null)
                throw new NullReferenceException("File json non trovato");

            try
            {

                await repo.GetItemByName(name, cancellationToken);
                await repo.IncrementItem(name, cancellationToken);

            }catch(Exception){ // Se non c'è l'item nel db, lo aggiungo

                foreach (Items item in extractedDataItem)
                {
                    if(item.ItemName == name)
                    {
                        await repo.AddItemsAsync(item, cancellationToken);
                        break;
                    }
                }
            }
        }

        public async Task<string> CreaSquadraCasuale(CancellationToken cancellationToken = default)
        {
            string squadra = "\nSquadra:\n";

            for(int i = 0; i < 6; i++)
            {
                PokemonDTO? PokemonDTO = await _clientHttp.PokemonRandomAsync(cancellationToken);

                if(PokemonDTO == null)
                    throw new NullReferenceException("Pokemon non trovato");

                squadra += "- " + PokemonDTO.PokemonName + "\n";
            }

            return squadra;
            
        }

        public async Task SvuotaZaino(CancellationToken cancellationToken = default)
        {
            await repo.RemoveAllItems();
        }

    }

}