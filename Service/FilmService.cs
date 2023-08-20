using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public class FilmService : IFilmService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string erro;

    public FilmService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool Add(FilmInput filmInput)
    {
        if (filmInput.Film_id == 0)
        {
            if (!_context.Film.Any(x => x.Title.ToLower() == filmInput.Title.ToLower()))
            {
                try
                {
                    Films film = _mapper.Map<Films>(filmInput);
                    _context.Film.Add(film);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    erro = ex.Message;
                    return false;
                }
            }
            else
            {
                erro = "Filme já existente";
                return false;
            }
        }
        else
        {
            try
            {
                Films film = _mapper.Map<Films>(filmInput);
                _context.Film.Update(film);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }


    }

    public List<FilmOutput> GetLista()
    {
        try
        {
            List<Films> Films = _context.Film.Include(x => x.Language).AsEnumerable().ToList();
            List<FilmOutput> filmOutputs = _mapper.Map<List<FilmOutput>>(Films);
            return filmOutputs;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return null;
        }
    }

    public bool Remover(int id)
    {
        try
        {
            Films films = _context.Film.Where(film => film.Film_id == id).FirstOrDefault();
            _context.Film.Remove(films);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return false;
        }
    }
}
