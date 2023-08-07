using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;

namespace WebExercicios.Services;
public class CategoriaProdutoService : ICategoriaProdutoService
{
    private readonly ExercicioContext context;
    private string erro ;

    public CategoriaProdutoService(ExercicioContext context)
    {
        this.context = context;
    }

    public bool Add(CategoriaProdutos categoria)
    {
        try{
            this.context.CategoriaProdutos.Add(categoria);
            return true;
        }catch(Exception erro){
            this.erro = erro.Message;
            return false;
        }
    }

    public IEnumerable<CategoriaProdutos> GetAll()
    {
        IEnumerable<CategoriaProdutos> lista = this.context.CategoriaProdutos.AsEnumerable();
        return lista;
    }
}
