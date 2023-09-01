using System.Linq.Expressions;

namespace WebExercicios.Services;
public interface IServiceBase<T> 
{
    List<Output> GetLista<Output>();  
    bool Add<Input>(Input input);
    bool Remove(params object[] chaves);
    Output GetItem<Output>(params object[] chaves);
    IServiceBase<T> GetQuery();
    IServiceBase<T> Include(Expression<Func<T, object>> func);
    List<Output> MapList<Output>();
}
