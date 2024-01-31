namespace PokemonCaptureService.ClientHttp.Abstraction
{
    public interface IClientHttp
    {
        Task<string> PokemonCasualeAsync(CancellationToken cancellationToken = default);
    }
}