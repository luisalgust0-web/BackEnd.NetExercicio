namespace WebExercicios.Services.Interfaces;
public interface IServiceBase<T> 
{
    bool Add<Input>(Input input);
    bool Update<Input>(Input input);
    bool Remove(params object[] chaves);
    Output GetItem<Output>(params object[] chaves);
    IConsultaBase<T> GetQuery();
}
