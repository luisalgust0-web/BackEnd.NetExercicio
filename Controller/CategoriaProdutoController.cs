using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class CategoriaProdutoController : ControllerBase  {

     private readonly ICategoriaProdutoService _categoriaProdutoService;

    public CategoriaProdutoController(ICategoriaProdutoService categoriaProdutoService)
    {
        _categoriaProdutoService = categoriaProdutoService;
    }

    [HttpGet("HelloWorld")]
    public string HelloWorld(){
        return "Hello World";
    }

    [HttpGet("GetListaCategoria")]
    public IActionResult GetLista(){
        List<CategoriaProdutosViewModel> list = _categoriaProdutoService.GetAll();
        return new JsonResult(list);
    }

    [HttpGet("GetCategoria")]
    public IActionResult GetCategoria(int id){
        CategoriaProdutosViewModel categoriaProdutos = _categoriaProdutoService.GetCategoriaProduto(id);
        return new JsonResult(categoriaProdutos);
    }

    [HttpPost("AddCategoria")]
    public bool AddCategoria(CategoriaProdutosViewModel categoriaProdutos){
        return _categoriaProdutoService.Add(categoriaProdutos);
    }

    [HttpPost("DeleteCategoria")]
    public bool DeleteCategoria(CategoriaProdutosViewModel categoriaProdutos){
        return _categoriaProdutoService.Delete(categoriaProdutos);
    }
}


 