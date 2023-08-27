using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class CategoryService : ICategoryService
{
    public readonly ExercicioContext _context;
    public readonly IMapper _mapper;
    public string erro;
    public CategoryService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public bool Add(CategoryInput categoryInput)
    {
        if (categoryInput.Category_id == 0)
        {
            if (!_context.Category.Any(x => x.Name.ToLower() == categoryInput.Name.ToLower()))
            {
                try
                {
                    Category category = _mapper.Map<Category>(categoryInput);
                    _context.Category.Add(category);
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
                erro = "Categoria ja existente";
                return false;
            }
        }
        else
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryInput);
                _context.Category.Update(category);
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

    public List<CategoryOutput> GetCategories()
    {
        try
        {
            List<Category> category = _context.Category.AsEnumerable().ToList();
            List<CategoryOutput> categoryOutputs = _mapper.Map<List<CategoryOutput>>(category);
            return categoryOutputs;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return null;
        }
    }

    public bool Remove(int id)
    {
        try
        {
            Category category = _context.Category.Where(x => x.Category_id == id).FirstOrDefault();
            _context.Category.Remove(category);
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
