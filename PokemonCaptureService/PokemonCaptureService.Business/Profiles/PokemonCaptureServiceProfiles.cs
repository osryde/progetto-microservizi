using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Shared;

namespace PokemonCaptureService.Business.Profiles;

/// <summary>
/// Marker per <see cref="AutoMapper"/>.
/// </summary>
public sealed class AssemblyMarker {
    AssemblyMarker() { }
}

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
public class InputFileProfile : Profile {
    public InputFileProfile() {
        CreateMap<PokemonDTO, Pokemon>();
        CreateMap<ItemDTO, Items>();
        CreateMap<Pokemon, PokemonDTO>();
        CreateMap<Items, ItemDTO>();
    }
}