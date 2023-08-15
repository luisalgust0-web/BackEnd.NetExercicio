using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels;

namespace WebExercicios.Services;
public class ProdutoService : IProdutoService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    private String erro;

    public ProdutoService(ExercicioContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    

    public List<ProdutoViewModel> GetLista()
    {
        try{
            List<Produto> listaProduto = _context.Produto.Include(x => x.CategoriaProdutos).AsEnumerable().ToList();
            List<ProdutoViewModel> listaProdutoViewModel = _mapper.Map<List<ProdutoViewModel>>(listaProduto);
            return listaProdutoViewModel;

        }catch(Exception ex){
            this.erro = ex.Message;
            return null;
        }
    }

    public ProdutoViewModel GetProduto(int id){
        try{
            Produto produto =_context.Produto.Where(x => x.Id == id).FirstOrDefault();
            ProdutoViewModel produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);
            return produtoViewModel;
        }catch(Exception ex){
            this.erro=ex.Message;
            return null;
        }
    }

    public bool Add(ProdutoViewModel produtoViewModel)
    {
        if(_context.CategoriaProdutos.Any(x => x.Id == produtoViewModel.CategoriaProdutosId)){
            try{
            Produto produto = _mapper.Map<Produto>(produtoViewModel);
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return true;
        }catch(Exception ex){
            this.erro = ex.Message;
            return false;
        }
        }else{
            return false;
        }
    }

    public bool Delete(ProdutoViewModel produtoViewModel)
    {
        try{
            Produto produto = _mapper.Map<Produto>(produtoViewModel);
            _context.Remove(produto);
            _context.SaveChanges();
            return true;
        }catch(Exception ex){   
            this.erro = ex.Message;
            return false;
        }
    }

    public bool remover(int id)
    {
        Produto produto = _context.Produto.Where(x => x.Id == id).FirstOrDefault();
        _context.Produto.Remove(produto);
        _context.SaveChanges();
        return true;
    }
}

