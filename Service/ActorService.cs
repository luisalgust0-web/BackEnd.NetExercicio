using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class ActorService : IActorService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string Erro;
    public ActorService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool Add(ActorInput actorInput)
    {
        if (!_context.Actor.Any(x => x.First_name.ToLower() == actorInput.First_name.ToLower() && x.Last_name.ToLower() == actorInput.Last_name.ToLower()))
        {
            Actor actor = _mapper.Map<Actor>(actorInput);

            if (actorInput.Actor_id == 0)
            {
                try
                {
                    _context.Actor.Add(actor);
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
                try
                {
                    _context.Actor.Update(actor);
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
        else
        {
            Erro = "Actor já existente";
            return false;
        }
    }

    public List<ActorOutput> GetLista()
    {
        try
        {
            List<Actor> actor = _context.Actor.AsEnumerable().ToList();
            List<ActorOutput> actorOutputs = _mapper.Map<List<ActorOutput>>(actor);
            return actorOutputs;
        }
        catch (Exception ex)
        {
            Erro = ex.Message;
            return null;
        }
    }

    public bool Remove(int id)
    {
        try
        {
            Actor actor = _context.Actor.Where(x => x.Actor_id == id).FirstOrDefault();
            _context.Actor.Remove(actor);
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
