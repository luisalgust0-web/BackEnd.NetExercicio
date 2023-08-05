using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase  {

     private readonly ExercicioContext context;

    public HomeController(ExercicioContext context)
    {
        this.context = context;
    }

    [HttpGet("HelloWorld")]
    public string HelloWorld(){
        return "Hello World";
    }

    [HttpGet("GetCategoria")]
    public string GetCategoria(){
        var teste = this.context.CategoriaProdutos.ToList();
        return "";
    }
}

 