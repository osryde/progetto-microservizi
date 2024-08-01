using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using PokedexService.Repository.Model;
using PokemonCaptureService.Shared;

namespace PokedexService.Business.Profiles;

public sealed class AssemblyMarker {
    AssemblyMarker() { }
}

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
public class InputFileProfile : Profile {
    public InputFileProfile() {
        CreateMap<PokemonDTO, Pokemon>();
        CreateMap<Pokemon, PokemonDTO>();
    }
}