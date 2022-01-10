using Microsoft.Extensions.DependencyInjection;
using PetStore.Repositories;
using PetStore.Resources;
using System.Threading.Tasks;

namespace PetStore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            await services.AddSingleton<PetStoreApp, PetStoreApp>()
                .BuildServiceProvider()
                .GetService<PetStoreApp>()
                .RunApp();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPetResource, PetResource>();
            services.AddScoped<IPetRepository, PetRepository>();
        }
    }
}
