using System.Linq.Expressions;

namespace WebExercicios.Services.Interfaces;
public interface IConsultaBase<T>
{
    IConsultaBase<T> Include(Expression<Func<T, object>> func);
    IConsultaBase<T> Where(Expression<Func<T, bool>> expression);
    List<Output> MapList<Output>();
}

