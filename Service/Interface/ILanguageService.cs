using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface ILanguageService
{
    public List<LanguageOutput> getLista();
    public bool Add(LanguageInput languageInput);
    public bool Delete(int id);
}
