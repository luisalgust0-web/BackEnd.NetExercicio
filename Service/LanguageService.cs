using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class LanguageService : ILanguageService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string erro;

    public LanguageService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool Add(LanguageInput languageInput)
    {
        if (!_context.Language.Any(x => x.Name.ToLower() == languageInput.Name.ToLower()))
        {
            try
            {
                Language language = _mapper.Map<Language>(languageInput);
                _context.Language.Add(language);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                this.erro = ex.Message;
                return false;
            }
        }
        else
        {
            erro = "this language already exists";
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            Language language = _context.Language.Where(x => x.Language_id == id).FirstOrDefault();
            _context.Language.Remove(language);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            this.erro = ex.Message;
            return false;
        }
    }

    public List<LanguageOutput> getLista()
    {
        try
        {
            List<Language> Languages = _context.Language.AsEnumerable().ToList();
            List<LanguageOutput> languageOutputs = _mapper.Map<List<LanguageOutput>>(Languages);
            return languageOutputs;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return null;
        }
    }
}
