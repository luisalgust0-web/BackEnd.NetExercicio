using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface IFilmService
{
    public List<FilmOutput> GetLista();
    public bool Add(FilmInput filmInput);
    public bool Remover(int id);
}
