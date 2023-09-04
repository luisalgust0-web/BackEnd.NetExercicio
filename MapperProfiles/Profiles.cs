using AutoMapper;
using Namespace;
using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.MapperProfiles;
public class Profiles : Profile
{
    public Profiles(){
        CreateMap<Citys, CityOutput>().ForMember( x => x.Country_Name, cfg => cfg.MapFrom( src => src.Country.Country));

        CreateMap<Countrys, CountryOutput>();

        CreateMap<Addresses, AddressOutput>().ForMember( x => x.City_Name, cfg => cfg.MapFrom( src => src.City.City));
        CreateMap<AddressInput, Addresses>();

        CreateMap<Language, LanguageOutput>();

        CreateMap<Film, FilmOutput>().ForMember( x => x.Language_Name, cfg => cfg.MapFrom( src => src.Language.Name)).ForMember( x => x.Original_Language_Name, cfg => cfg.MapFrom( src => src.Original_language.Name));

        CreateMap<Actor, ActorOutput>();

        CreateMap<Category, CategoryOutput>();

        CreateMap<Film_actor, Film_actorOutput>().ForMember(x => x.Film_Name, cfg => cfg.MapFrom( src => src.Film.Title)).ForMember(x => x.Actor_First_Name , cfg => cfg.MapFrom( src => src.Actor.First_name)).ForMember(x => x.Actor_Last_Name , cfg => cfg.MapFrom( src => src.Actor.Last_name));

        CreateMap<Inventory, InventoryOutput>().ForMember(x => x.Film_Name, cfg => cfg.MapFrom(src => src.Film.Title)).ForMember(x => x.Story_Address, cfg => cfg.MapFrom(src => src.Store.Address.Address)).ForMember(x => x.Story_City, cfg => cfg.MapFrom(src => src.Store.Address.City));;

        CreateMap<Customer, CustomerOutput>().ForMember(x => x.Customer_Address, cfg => cfg.MapFrom(src => src.Address.Address)).ForMember(x => x.Customer_Address_City, cfg => cfg.MapFrom(src => src.Address.City));
    }
}
