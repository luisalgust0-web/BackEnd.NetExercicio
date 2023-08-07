using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Services.Interfaces;
public interface ICategoriaProdutoService
{
    public bool Add(CategoriaProdutos categoria);

    public IEnumerable<CategoriaProdutos> GetAll();
}