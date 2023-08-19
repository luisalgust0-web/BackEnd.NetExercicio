using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase  {

     private readonly ExercicioContext context;
     private readonly ICountryService _service;

    public CountryController(ExercicioContext context,ICountryService service)
    {
        _service = service;
        this.context = context;
    }

    [HttpGet("GetCountrys")]
    public IActionResult GetCountrys(){
        List<CountryOutput> lista = _service.GetLista();       
        return new JsonResult(lista);
    }

    [HttpPost("AddCountry")]
    public bool Add(CountryInput countryInput){
        return _service.Add(countryInput);
    }

    [HttpDelete("DelteCountry/{id}")]
    public bool Delete(int id){
        return _service.Delete(id);
    }
}

 