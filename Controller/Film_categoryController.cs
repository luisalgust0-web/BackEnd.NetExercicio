using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class Film_categoryController : ControllerBase
{
    private readonly IServiceBase<Film_category> _service;

    public Film_categoryController(IServiceBase<Film_category> service)
    {
        _service = service;
    }

    // [HttpGet("GetLista")]
    // public IActionResult GetFilm_categorys(){
    //     return new JsonResult(_service.GetQuery().Include( x => x.Category).Include( x => x.Film ).MapList<Film_categoryOutput>());
    // }

    [HttpGet("GetListaByFilmTitle")]
    public IActionResult GetFilm_categorysByFilmTitle(string title){
        return new JsonResult(_service.GetQuery().Where(x => x.Film.Title.Contains(title)).Include( x => x.Category).Include( x => x.Film ).MapList<Film_categoryOutput>());
    }

    [HttpGet("GetListaFilmCategorys")]
    public IActionResult GetFilm_categorys([FromQuery]string title,[FromQuery]int? categoryId,[FromQuery]int? languageId){
        var query = _service.GetQuery().Where(x => x.Film.Title.Contains(title));

        if(categoryId.HasValue){
            query = query.Where(x => x.Category_id == categoryId);
        }

        if(languageId.HasValue){
            query = query.Where( x => x.Film.Language_id == languageId);
        }

        return new JsonResult(query.Include( x => x.Category).Include( x => x.Film ).MapList<Film_categoryOutput>());
    }

}
