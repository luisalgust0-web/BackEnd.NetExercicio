using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    public readonly ILanguageService _service;
    public LanguageController(ILanguageService service){
        _service = service;
    }

    [HttpGet("GetLanguages")]
    public IActionResult GetLista(){
        List<LanguageOutput> languageOutpus = _service.getLista();
        return new JsonResult(languageOutpus);
    }

    [HttpPost("AddLanguages")]
    public bool Add(LanguageInput languageInput){
        return _service.Add(languageInput);
    }

    [HttpDelete("DeleteLanguage/{id}")]
    public bool Delete(int id){
       return _service.Delete(id);
    }
}
