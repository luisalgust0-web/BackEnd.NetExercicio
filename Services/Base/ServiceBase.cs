using System.Linq.Expressions;
using System.Transactions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Services;

namespace WebExercicios.Services.Base;
public class ServiceBase<T> : IServiceBase<T> where T : class
{
    private readonly IMapper _mapper;
    private readonly ExercicioContext _context;
    private IQueryable<T> query;

    public ServiceBase(IMapper mapper, ExercicioContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public virtual bool Add<Input>(Input input)
    {

        var DbModel = _mapper.Map<T>(input);
        _context.Set<T>().Add(DbModel);
        _context.SaveChanges();
        return true;
    }

    public Output GetItem<Output>(params object[] chaves)
    {
        T entity = _context.Find<T>(chaves);
        Output output = _mapper.Map<Output>(entity);
        return output;
    }

    public virtual List<Output> GetLista<Output>()
    {
        List<T> ListDbModel = _context.Set<T>().AsEnumerable().ToList();
        List<Output> ListOutputModel = _mapper.Map<List<Output>>(ListDbModel);
        return ListOutputModel;
    }

    public bool Remove(params object[] chaves)
    {
        T entity = _context.Find<T>(chaves);
        _context.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public IServiceBase<T> GetQuery(){
        this.query = _context.Set<T>().Where(x => true);
        return this; 

    }

    public IServiceBase<T> Include(Expression<Func<T, object>> func)
    {
        this.query = this.query.Include(func);
        return this; 
    }
    
    public List<Output> MapList<Output>(){
        List<T> lista = this.query.ToList();
        return  _mapper.Map<List<Output>>(lista);
    }
}
