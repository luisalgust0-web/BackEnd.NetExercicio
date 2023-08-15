using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels;

namespace WebExercicios.Services.Interfaces;
public interface IProdutoService
{
    public List<ProdutoViewModel> GetLista();
    public ProdutoViewModel GetProduto(int id);
    public bool Add(ProdutoViewModel produtoViewModel);
    public bool Delete(ProdutoViewModel produtoViewModel);
    public bool remover(int id);
}
