using AutoMapper;
using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.AutoMapper;
public class Profiles : Profile
{
    public Profiles()
    {
        // CreateMap<CategoriaProdutos, CategoriaProdutosViewModel>(MemberList.None);
        CreateMap<CountryInput, Countrys>();
        CreateMap<Countrys, CountryOutput>();

        CreateMap<Citys, CityOutput>().ForMember(x => x.CountryName, src => src.MapFrom(src => src.Country.Country));
        CreateMap<CityInput, Citys>();

        CreateMap<Addresses, AddressesOutput>().ForMember(x => x.CityName, src => src.MapFrom(src => src.City.City));
        CreateMap<AddressesInput, Addresses>();

        CreateMap<Language, LanguageOutput>();
        CreateMap<LanguageInput, Language>();

        CreateMap<Films, FilmOutput>()
        .ForMember(x => x.LanguageName, src => src.MapFrom(src => src.Language.Name))
        .ForMember(x => x.OriginaLanguageName, src => src.MapFrom(src => src.LanguageOriginal.Name));
        CreateMap<FilmInput, Films>();

        CreateMap<Category, CategoryOutput>();
        CreateMap<CategoryInput, Category>();

        CreateMap<FilmCategory, FilmCategoryOutput>()
        .ForMember(x => x.CategoryName , src => src.MapFrom(x => x.Category.Name))
        .ForMember(x => x.FilmName , src => src.MapFrom(x => x.Film.Title));
        CreateMap<FilmCategoryInput, FilmCategory>();

        CreateMap<Actor, ActorOutput>();
        CreateMap<ActorInput, Actor>();

        CreateMap<FilmActorInput, FilmActor>();
        CreateMap<FilmActor, FilmActorOutput>()
        .ForMember(x => x.ActorFirstName , cfg => cfg.MapFrom(src => src.Actor.First_name))
        .ForMember(x => x.ActorLastName , cfg => cfg.MapFrom(src => src.Actor.Last_name))
        .ForMember(x => x.FilmTitle , cfg => cfg.MapFrom(src => src.Film.Title));
   }
}
