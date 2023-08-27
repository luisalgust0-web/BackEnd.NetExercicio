using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface IActorService
{
    public bool Add(ActorInput actorInput);
    public bool Remove(int id);
    public List<ActorOutput> GetLista();
}
