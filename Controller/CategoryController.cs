using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet("GetCategories")]
    public IActionResult GetCategories(){
        List<CategoryOutput> categories =_service.GetCategories();
        return new JsonResult(categories);
    }

    [HttpPost("AddCategory")]
    public bool Add(CategoryInput categoryInput){
        return _service.Add(categoryInput);
    }

    [HttpDelete("DeleteCategory/{id}")]
    public bool Delete(int id){
        return _service.Remove(id);
    }
}
