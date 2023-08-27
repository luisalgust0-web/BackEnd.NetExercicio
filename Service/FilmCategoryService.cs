using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class FilmCategoryService : IFilmCategoryService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string erro;
    public FilmCategoryService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<FilmCategoryOutput> FilmesPorCategoria(string category)
    {
        try{
            List<FilmCategory > filmCategories = _context.FilmCategories.Include(x => x.Category).Include(x => x.Film).Where(c => c.Category.Name.ToLower() == category.ToLower()).ToList();
            List<FilmCategoryOutput> filmCategoryOutputs = _mapper.Map<List<FilmCategoryOutput>>(filmCategories);
            return filmCategoryOutputs;
        }catch(Exception ex){
            erro = ex.Message;
            return null;
        }
    }
    public List<FilmCategoryOutput> GetAll()
    {
        try{
          List<FilmCategory> filmCategories = _context.FilmCategories.Include(x => x.Category).Include(x => x.Film).AsEnumerable().ToList();
          List<FilmCategoryOutput> filmCategoryOutputs = _mapper.Map<List<FilmCategoryOutput>>(filmCategories);
          return filmCategoryOutputs;
        }catch(Exception ex){
            erro = ex.Message;
            return null;
        }
    }
}
