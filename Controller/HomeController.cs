using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase  {

     private readonly ExercicioContext _context;
     private readonly CategoriaProdutoService _categoriaProdutoService;

    public HomeController(ExercicioContext context, CategoriaProdutoService categoriaProdutoService)
    {
        _context = context;
        _categoriaProdutoService = categoriaProdutoService;
    }

    [HttpGet("HelloWorld")]
    public string HelloWorld(){
        return "Hello World";
    }

    [HttpGet("GetCategoria")]
    public IEnumerable<CategoriaProdutos> GetCategoria(){
        IEnumerable<CategoriaProdutos> list = _categoriaProdutoService.GetAll();
        return list;
    }

    [HttpPost("AddCategoria")]
    public bool AddCategoria(CategoriaProdutos categoriaProdutos){
        _categoriaProdutoService.Add(categoriaProdutos);
        return true;
    }
}


 