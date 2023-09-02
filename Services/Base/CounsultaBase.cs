using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Services.Interfaces;

namespace WebExercicios.Services.Base;
public class ConsultaBase<T> : IConsultaBase<T> where T : class
{
    // IIncludableQueryable<T>
    private IQueryable<T> _query;
    private readonly IMapper _mapper;

    public ConsultaBase(IQueryable<T> query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public IConsultaBase<T> Include(Expression<Func<T, object>> func)
    {
        this._query = _query.Include(func);
        return this;
    }

    public List<Output> MapList<Output>()
    {
        List<T> lista = _query.ToList();
        return _mapper.Map<List<Output>>(lista);
    }

    public IConsultaBase<T> Where(Expression<Func<T, bool>> expression)
    {
        this._query = _query.Where(expression);
        return this;
    }
}
