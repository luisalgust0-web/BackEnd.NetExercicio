using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class CityService : ICityService
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public string erro;
    public CityService(ExercicioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool Add(CityInput cityInput)
    {
        try
        {
            if (cityInput.City_id == 0)
            {
                if (!_context.City.Any(x => x.City.ToLower() == cityInput.City.ToLower()))
                {
                    Citys citys = _mapper.Map<Citys>(cityInput);
                    _context.Add(citys);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    erro = "cidade já existente";
                    return false;
                }
            }
            else
            {
                Citys citys = _mapper.Map<Citys>(cityInput);
                _context.Update(citys);
                _context.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return false;
        }
    }

    public bool Delete(int Id)
    {
        try
        {
            Citys city = _context.City.Where(x => x.City_id == Id).FirstOrDefault();
            _context.City.Remove(city);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return false;
        }

    }

    public List<CityOutput> GetAll()
    {
        try
        {
            List<Citys> ListCitys = _context.City.Include(x => x.Country).AsEnumerable().ToList();
            return _mapper.Map<List<CityOutput>>(ListCitys);
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return null;
        }
    }
}
