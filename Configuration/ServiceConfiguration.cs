
using WebExercicios.Service;
using WebExercicios.Service.Interface;

namespace WebExercicios.Configuration;
public static class ServiceConfiguration2
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            // serviceCollection.AddScoped<IReceitaService, ReceitaService>();
            serviceCollection.AddScoped<ILanguageService, LanguageService>();
            serviceCollection.AddScoped<ICityService, CityService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<IAddressesService, AddressesService>();
            serviceCollection.AddScoped<ILanguageService, LanguageService>();
            serviceCollection.AddScoped<IFilmService, FilmService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IFilmCategoryService, FilmCategoryService>();
            serviceCollection.AddScoped<IActorService, ActorService>();
            serviceCollection.AddScoped<IFilmActorService, FilmActorService>();
            return serviceCollection;
        }

    }
