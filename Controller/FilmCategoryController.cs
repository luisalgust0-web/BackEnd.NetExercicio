using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class FilmCategoryController : ControllerBase
{
    private readonly IFilmCategoryService _filmCategoryService;
    public FilmCategoryController (IFilmCategoryService filmCategoryService) {
        _filmCategoryService = filmCategoryService;
    }

    [HttpGet("GetFilmCaegorys")]
    public IActionResult GetFilmCategory(){
        List<FilmCategoryOutput> filmCategoryOutputs = _filmCategoryService.GetAll();
        return new JsonResult(filmCategoryOutputs);
    }

    [HttpGet("GetFilmPorCaegory")]
    public IActionResult GetFilmPorCategory(string categoria){
        List<FilmCategoryOutput> filmCategoryOutputs = _filmCategoryService.FilmesPorCategoria(categoria);
        return new JsonResult(filmCategoryOutputs);
    }
}
