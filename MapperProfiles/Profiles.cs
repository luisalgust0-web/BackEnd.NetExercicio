using AutoMapper;
using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.MapperProfiles;
public class Profiles : Profile
{
    public Profiles(){
        CreateMap<Language, LanguageOutput>();

        CreateMap<Citys, CityOutput>().ForMember( x => x.Country_name, cfg => cfg.MapFrom( src => src.Country.Country));
    }
}
