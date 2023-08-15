using WebExercicios.Services;
using WebExercicios.Services.Interfaces;

namespace WebExercicios.Configuration;
public static class ServiceConfiguration
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
            return serviceCollection;
        }

    }
