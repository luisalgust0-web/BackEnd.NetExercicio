using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface IFilmActorService
{
    public bool Add(FilmActorInput filmActorInput);
    public bool Remove(int filmId, int actorId);
    public List<FilmActorOutput> GetFilmActors();
    public List<FilmActorOutput> GetFilmsByActor(string actorFName,string actorLName);
    public List<FilmActorOutput> GetActorsByFilm(string film);
}
