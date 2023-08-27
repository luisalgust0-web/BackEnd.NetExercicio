using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface ICategoryService
{
    public List<CategoryOutput> GetCategories();
    public bool Add(CategoryInput categoryInput);
    public bool Remove(int id);
}
