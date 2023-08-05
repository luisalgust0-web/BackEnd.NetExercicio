namespace WebExercicios.Configuration;
public static class ServiceConfiguration2
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            // serviceCollection.AddScoped<IReceitaService, ReceitaService>();
            
            return serviceCollection;
        }

    }
