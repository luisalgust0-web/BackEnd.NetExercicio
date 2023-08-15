using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels;

namespace WebExercicios.Services;
public class CategoriaProdutoService : ICategoriaProdutoService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper; 
    private string erro ;

    public CategoriaProdutoService(ExercicioContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public bool Add(CategoriaProdutosViewModel categoria)
    {

        CategoriaProdutos categoriaProdutos = _mapper.Map<CategoriaProdutos>(categoria);

        try{
            _context.CategoriaProdutos.Add(categoriaProdutos);
            _context.SaveChanges();
            return true;
        }catch(Exception erro){
            this.erro = erro.Message;
            return false;
        }
    }

    public List<CategoriaProdutosViewModel> GetAll()
    {
        try{
            List<CategoriaProdutos> lista = _context.CategoriaProdutos.AsEnumerable().ToList();
            List<CategoriaProdutosViewModel> listaViewModel = _mapper.Map<List<CategoriaProdutosViewModel>>(lista);
            return listaViewModel;
        }catch(Exception ex){
            this.erro = ex.Message;
            return null;
        }
        
    }

    public CategoriaProdutosViewModel GetCategoriaProduto(int id){
        try{
            CategoriaProdutos categoriaProdutos = _context.CategoriaProdutos.Where(x => x.Id == id).FirstOrDefault();
            CategoriaProdutosViewModel categoriaProdutosViewModel = _mapper.Map<CategoriaProdutosViewModel>(categoriaProdutos);
            return categoriaProdutosViewModel;
        }catch(Exception ex){
            this.erro = ex.Message;
            return null;
        }
    }

    public bool Delete(CategoriaProdutosViewModel categoria){
        CategoriaProdutos categoriaProdutos = _mapper.Map<CategoriaProdutos>(categoria);

        try{
            _context.CategoriaProdutos.Remove(categoriaProdutos);
            _context.SaveChanges();
            return true;
        }catch(Exception erro){
            this.erro = erro.Message;
            return false;
        }
    }
}
