using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using PokemonTrainerService.Repository.Model;
using PokemonCaptureService.Shared;

namespace PokemonTrainerService.Business.Profiles;

public sealed class AssemblyMarker {
    AssemblyMarker() { }
}

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
public class InputFileProfile : Profile {
    public InputFileProfile() {
        CreateMap<ItemDTO, Items>();
        CreateMap<Items, ItemDTO>();
    }
}