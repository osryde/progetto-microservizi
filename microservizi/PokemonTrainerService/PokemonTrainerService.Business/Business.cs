using PokemonTrainerService.Business.Abstraction;
using PokemonTrainerService.Repository.Model;
using PokemonTrainerService.Repository.Abstraction;


namespace PokemonTrainerService.Business
{
    public class Business : IBusiness
    {   

        private IRepository repo;
        
        public Business(IRepository repository)
        {
            repo = repository;
        }

        public async Task<IEnumerable<Item>> ListaZaino(CancellationToken cancellationToken = default)
        {
            IEnumerable<Item> items = await repo.GetAllItems();
            return items;
        }
        public async Task<Item> AggiungiOggetto(Item item, CancellationToken cancellationToken = default)
        {
            using FileStream dati = File.OpenRead("items.json");
            
            // Controllo se l'item dato è valido
            var extractedDataItem = JsonSerializer.Deserialize<List<Item>>(dati);

            if(extractedDataItem == null)
                throw new NullReferenceException("File json non trovato");

            try
            {

                await repo.Get(name, cancellationToken);

            }catch(Exception){

                foreach (Item item in extractedDataItem)
                {
                    if(item.ItemName == name)
                    {
                        await repo.AddItemsAsync(item, cancellationToken);
                        break;
                    }
                }
            }
        }

        public async Task<String> CreaSquadraCasuale(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException(); // DA FARE con HttpClient
        }
    }

}