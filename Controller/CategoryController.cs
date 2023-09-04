using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IServiceBase<Category> _service;

    public CategoryController(IServiceBase<Category> service)
    {
        _service = service;   
    }

    [HttpGet("GetLista")]
    public IActionResult GetCategorys(){
        return new JsonResult(_service.GetQuery().MapList<CategoryOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetCategory(int id){
        return new JsonResult(_service.GetItem<CategoryOutput>(id));
    }
}
