using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class FilmActorService : IFilmActorService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string Erro;
    public FilmActorService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public bool Add(FilmActorInput filmActorInput)
    {
        if (!_context.FilmActors.Any(x => x.Actor_id == filmActorInput.Actor_id && x.Film_id == filmActorInput.Film_id))
        {
           FilmActor filmActor = _mapper.Map<FilmActor>(filmActorInput);
            try
            {
                _context.FilmActors.Add(filmActor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return false;
            }
        }
        else
        {
            Erro = "the actor is already in this movieActor just be on this move";
            return false;
        }

    }

    public List<FilmActorOutput> GetActorsByFilm(string film)
    {
        try
        {
            List<FilmActor> filmActor =_context.FilmActors.Include(x => x.Actor).Include(x => x.Film).Where(x => x.Film.Title.ToLower() == film.ToLower()).ToList();
            List<FilmActorOutput> filmActorOutputs = _mapper.Map<List<FilmActorOutput>>(filmActor);
            return filmActorOutputs;
        }
        catch (Exception ex)
        {
            Erro = ex.Message;
            return null;
        }
    }

    public List<FilmActorOutput> GetFilmActors()
    {
        try
        {
            List<FilmActor> filmActor =_context.FilmActors.Include(x => x.Actor).Include(x => x.Film).AsEnumerable().ToList();
            List<FilmActorOutput> filmActorOutputs = _mapper.Map<List<FilmActorOutput>>(filmActor);
            return filmActorOutputs;
        }
        catch (Exception ex)
        {
            Erro = ex.Message;
            return null;
        }
    }

    public List<FilmActorOutput> GetFilmsByActor(string actorFName,string actorLName)
    {
        try
        {
            List<FilmActor> filmActors =_context.FilmActors.Include(x => x.Actor).Include(x => x.Film).Where(x => x.Actor.First_name.ToLower()  == actorFName.ToLower() && x.Actor.Last_name.ToLower() == actorLName.ToLower()).ToList();
            List<FilmActorOutput> filmActorOutputs = _mapper.Map<List<FilmActorOutput>>(filmActors);
            return filmActorOutputs;
        }
        catch (Exception ex)
        {
            Erro = ex.Message;
            return null;
        }
    }

    public bool Remove(int filmId, int actorId)
    {
        try
        {
            FilmActor filmActor = _context.FilmActors.Where(x => x.Film_id == filmId && x.Actor_id == actorId).FirstOrDefault();
            _context.FilmActors.Remove(filmActor);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Erro = ex.Message;
            return false;
        }
    }
}
