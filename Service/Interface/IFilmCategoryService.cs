using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface IFilmCategoryService
{
    public List<FilmCategoryOutput> GetAll();
    public List<FilmCategoryOutput> FilmesPorCategoria(string category);
}
