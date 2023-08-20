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
        CreateMap<Films, FilmOutput>().ForMember(x => x.LanguageName, src => src.MapFrom(src => src.Language.Name)).ForMember(x => x.OriginaLanguageName, src => src.MapFrom(src => src.LanguageOriginal.Name));
        CreateMap<FilmInput, Films>(); 
   }
}
