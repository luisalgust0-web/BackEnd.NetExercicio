using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet("GetListaProduto")]
    public ActionResult GetLista(){
        List<ProdutoViewModel> lista = _service.GetLista();
        return new JsonResult(lista);
    }

    [HttpPost("AdicionarProduto")]
    public bool AdicionarProduto(ProdutoViewModel produtoViewModel){
        return _service.Add(produtoViewModel);
    }

    [HttpPost("RemoveProduto")]
    public bool RemoveProduto(ProdutoViewModel produtoViewModel){
        return _service.Delete(produtoViewModel);
    }

    [HttpDelete("Deletar/{id}")]
    public bool Delete(int id){
        return _service.remover(id);
    }

    [HttpGet("GetProduto")]
    public IActionResult GetProduto(int id){
        ProdutoViewModel produto = _service.GetProduto(id);
        return new JsonResult(produto);
    }
}
