using Microsoft.Extensions.DependencyInjection;
using Soenneker.Cosmos.Container.Registrars;
using Soenneker.Cosmos.Database.Registrars;

namespace Soenneker.Cosmos.Suite.Registrars;

/// <summary>
/// A concoction of Azure Cosmos utilities and libraries <para/>
/// </summary>
public static class CosmosSuiteRegistrar
{
    /// <summary>
    /// Adds all the Azure Cosmos utilities needed for use <para/>
    /// </summary>
    /// <param name="services"></param>
    public static void AddCosmosSuite(this IServiceCollection services)
    {
        services.AddCosmosContainerUtilAsSingleton();
        services.AddCosmosDatabaseUtilAsSingleton();
    }
}