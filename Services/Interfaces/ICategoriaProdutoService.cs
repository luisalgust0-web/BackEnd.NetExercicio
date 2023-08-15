using WebExercicios.Infra.Database.Models;
using WebExercicios.ViewModels;

namespace WebExercicios.Services.Interfaces;
public interface ICategoriaProdutoService
{
    public bool Add(CategoriaProdutosViewModel categoria);
    public List<CategoriaProdutosViewModel> GetAll();
    public CategoriaProdutosViewModel GetCategoriaProduto(int id);
    public bool Delete(CategoriaProdutosViewModel categoria);
}