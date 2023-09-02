using AutoMapper;
using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.MapperProfiles;
public class Profiles : Profile
{
    public Profiles(){
        CreateMap<Language, LanguageOutput>();

        CreateMap<Citys, CityOutput>().ForMember( x => x.Country_name, cfg => cfg.MapFrom( src => src.Country.Country));

        CreateMap<Countrys, CountryOutput>();

        CreateMap<Addresses, AddressOutput>().ForMember( x => x.City_Name, cfg => cfg.MapFrom( src => src.City.City));
    }
}
