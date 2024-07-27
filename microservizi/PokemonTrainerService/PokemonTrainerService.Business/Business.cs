using PokemonTrainerService.Business.Abstraction;
using PokemonTrainerService.Repository.Model;
using PokemonTrainerService.Repository.Abstraction;
using System.Text.Json;

namespace PokemonTrainerService.Business
{
    public class Business : IBusiness
    {   

        private IRepository repo;
        
        public Business(IRepository repository)
        {
            repo = repository;
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

        public Task<String> CreaSquadraCasuale(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException(); // DA FARE con HttpClient
        }

        public async Task SvuotaZaino(CancellationToken cancellationToken = default)
        {
            await repo.RemoveAllItems();
        }

    }

}