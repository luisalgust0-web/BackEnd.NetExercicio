using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Services.Interfaces;

namespace WebExercicios.Services.Base;
public class ServiceBase<T> : IServiceBase<T> where T : class
{
    private readonly IMapper _mapper;
    private readonly ExercicioContext _context;

    public ServiceBase(IMapper mapper, ExercicioContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public virtual bool Add<Input>(Input input)
    {

        T entity = _mapper.Map<T>(input);
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return true;
    }

    public Output GetItem<Output>(params object[] chaves)
    {
        T entity = _context.Find<T>(chaves);
        Output output = _mapper.Map<Output>(entity);
        return output;
    }
    
    public bool Remove(params object[] chaves)
    {
        T entity = _context.Find<T>(chaves);
        _context.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public virtual bool Update<Input>(Input input)
    {
        T entity = _mapper.Map<T>(input);
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return true;
    }

    public virtual IConsultaBase<T> GetQuery()
    {
        IQueryable<T> query = _context.Set<T>().Where(x => true);
        IConsultaBase<T> consultaQuery = new ConsultaBase<T>(query, _mapper);
        return consultaQuery;
    }

}


