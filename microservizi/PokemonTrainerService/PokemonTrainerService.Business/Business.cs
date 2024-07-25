using PokemonTrainerService.Business.Abstraction;
using PokemonTrainerService.Repository.Model;
using PokemonTrainerService.Repository.Abstraction;


namespace PokemonTrainerService.Business
{
    public class Business : IBusiness
    {   

        private IRepository repo;
        //private readonly PokemonTrainerService.ClientHttp.Abstraction.IClientHttp _clientHttp;
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
            throw new System.NotImplementedException(); // DA FARE
        }

        public async Task<String> CreaSquadraCasuale(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException(); // DA FARE 
        }
    }

}