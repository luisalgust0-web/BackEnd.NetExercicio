using AutoMapper;
using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;

namespace WebExercicios.AutoMapper;
public class Profiles : Profile
{
    public Profiles()
    {
        // CreateMap<CategoriaProdutos, CategoriaProdutosViewModel>(MemberList.None);
        CreateMap<CountryInput, Countrys>();
    }
}
