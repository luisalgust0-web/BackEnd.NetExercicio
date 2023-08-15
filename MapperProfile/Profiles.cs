using AutoMapper;
using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels;

namespace WebExercicios.MapperProfile;
public class Profiles : Profile
{

    public Profiles()
    {
        this.CreateMap<CategoriaProdutos, CategoriaProdutosViewModel>(MemberList.None);
        this.CreateMap<CategoriaProdutosViewModel, CategoriaProdutos>(MemberList.None);
        this.CreateMap<Produto, ProdutoViewModel>(MemberList.None).ForMember(x => x.NomeCategoria, cfg => cfg.MapFrom(src => src.CategoriaProdutos.Nome));
        this.CreateMap<ProdutoViewModel, Produto>(MemberList.None);
    }
}