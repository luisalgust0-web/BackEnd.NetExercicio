using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _service;
    public CityController(ICityService service)
    {
        _service = service;
    }

    [HttpGet("GetCitys")]
    public IActionResult GetCitys(){
        List<CityOutput> List =  _service.GetAll();
        return new JsonResult(List);
    }

    [HttpPost("AddCity")]
    public bool Add(CityInput cityInput){
        return _service.Add(cityInput);
    } 

    [HttpDelete("DeleteCity/{id}")]
    public bool Delete(int id){
        return _service.Delete(id);
    }
}
